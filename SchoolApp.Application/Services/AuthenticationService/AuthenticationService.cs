using SchoolApp.Application.Services.UserService;
using System.Security.Cryptography;

namespace SchoolApp.Application.Services.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    #region Fields
    private readonly JwtSettings _jwtSettings;
    private readonly IRefreshTokenRepository _refreshTokenRepo;
    private readonly IUserService _userService;
    private readonly SymmetricSecurityKey _signaturekey;
    private static string _SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature;
    private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
    #endregion

    #region Constructor(s)
    public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepo, IUserService userService)
    {
        _jwtSettings = jwtSettings;
        _refreshTokenRepo = refreshTokenRepo;
        _signaturekey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));
        _userService = userService;
    }
    #endregion

    #region Methods
    public async Task<JwtAuthResult> GetJwtAuthForuser(User User)
    {
        // 1) Generate jwtAccessTokon Object And String
        var (jwtAccessTokenObj, jwtAccessTokenString) = await GenerateAccessToken(User);

        // 2) Generate RefreshToken Object
        var refreshTokenObj = GenerateRefreshToken(User);

        // 3) Generate the JwtAuth for the user
        var jwtAuthResult = new JwtAuthResult
        {
            AccessToken = jwtAccessTokenString,
            RefreshToken = refreshTokenObj
        };

        // 4) Save AccessToken, RefreshToken In UserRefreshToken Table
        var refreshTokenEntity = new UserRefreshToken
        {
            UserId = User.Id,
            AccessToken = jwtAccessTokenString,
            RefreshToken = HashString(refreshTokenObj.Value),
            JwtId = jwtAccessTokenObj.Id,
            IsUsed = true,
            IsRevoked = false,
            CreatedAt = DateTime.UtcNow,
            ExpiryDate = refreshTokenObj.ExpiresAt,
        };
        var result = await _refreshTokenRepo.AddAsync(refreshTokenEntity);

        // 5) return the AuthResult for the user
        return jwtAuthResult;
    }

    public bool IsValidAccessToken(string AccessTokenStr)
    {
        try
        {
            var (jwtAccessTokenObj, jwtAccesTokenEx) = GetJwtAccessTokenObjFromAccessTokenString(AccessTokenStr);
            if (jwtAccesTokenEx != null) return false;

            GetClaimsPrinciple(AccessTokenStr);

            if (jwtAccessTokenObj!.ValidTo < DateTime.UtcNow) return false;

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion


    #region AccessToken Methods
    private List<Claim> GenerateUserClaims(User User, List<string> Roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, User.UserName),
            new Claim(ClaimTypes.Name, User.UserName),
            new Claim(ClaimTypes.Email, User.Email),
            new Claim(nameof(UserClaimModel.Id), User.Id.ToString()),
        };

        foreach (var role in Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }
    private async Task<(JwtSecurityToken, string)> GenerateAccessToken(User User)
    {
        List<string> roles = await _userService.GetUserRolesAsync(User);

        var Obj = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: GenerateUserClaims(User, roles),
            expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(_signaturekey, _SecurityAlgorithm)
        );
        var Value = new JwtSecurityTokenHandler().WriteToken(Obj);
        return (Obj, Value);
    }
    public (JwtSecurityToken?, Exception?) GetJwtAccessTokenObjFromAccessTokenString(string AccessToken)
    {
        try
        {
            return ((JwtSecurityToken)_tokenHandler.ReadToken(AccessToken), null);
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }
    public (ClaimsPrincipal?, Exception?) GetClaimsPrinciple(string AccessToken)
    {
        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = _jwtSettings.ValidateIssuer,
            ValidIssuers = new[] { _jwtSettings.Issuer },

            ValidateAudience = _jwtSettings.ValidateAudience,
            ValidAudience = _jwtSettings.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var principal = _tokenHandler.ValidateToken(AccessToken, parameters, out SecurityToken validationToken);

            if (validationToken is JwtSecurityToken jwtToken && jwtToken.Header.Alg.Equals(_SecurityAlgorithm))
                return (principal, null);

            return (null, new ArgumentNullException("Claims principle is null"));
        }
        catch (Exception ex)
        {
            return (null, ex);
        }
    }


    public (int, Exception?) GetUserIdFromJwtAccessTokenObj(JwtSecurityToken jwtAccessTokenObj)
    {
        if (!int.TryParse(jwtAccessTokenObj.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id))?.Value, out int UserId))
            return (0, new ArgumentNullException("Invalid user id"));

        return (UserId, null);
    }
    #endregion


    #region RefreshToken Methods
    private RefreshToken GenerateRefreshToken(User User)
    {
        return new RefreshToken()
        {
            Username = User.UserName,
            Value = GenerateRandomString64Length(),
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate)
        };
    }
    public async Task<(UserRefreshToken?, Exception?)> ValidateRefreshToken(int UserId, string AccessTokenStr, string RefreshTokenStr)
    {
        var hashedRefreshTokenStr = HashString(RefreshTokenStr);

        var refreshTokenEntity = await _refreshTokenRepo
            .GetTableNoTracking()
            .FirstOrDefaultAsync(x =>
                x.UserId == UserId &&
                x.AccessToken.Equals(AccessTokenStr) &&
                x.RefreshToken.Equals(hashedRefreshTokenStr)
            );

        if (refreshTokenEntity == null)
            return (null, new SecurityTokenArgumentException("Refresh token entity is null"));

        if (refreshTokenEntity.ExpiryDate < DateTime.UtcNow)
        {
            refreshTokenEntity.IsRevoked = true;
            refreshTokenEntity.IsUsed = false;
            await _refreshTokenRepo.UpdateAsync(refreshTokenEntity);
            return (null, new SecurityTokenArgumentException("Revoked refresh token"));
        }

        return (refreshTokenEntity, null);
    }
    #endregion


    #region Helpers
    private string GenerateRandomString64Length()
    {
        var randomNumber = new byte[32];
        using (var randomNumberGenerator = RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(randomNumber);
        }
        return Convert.ToBase64String(randomNumber);
    }

    private string HashString(string Value)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Value)).ToArray();
            return Convert.ToBase64String(hashedBytes);
        }
    }
    #endregion
}
