using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Application.Services.AuthenticationService;

public interface IAuthenticationService
{
    Task<JwtAuthResult> GetJwtAuthForuser(User User);
    (int, Exception?) GetUserIdFromJwtAccessTokenObj(JwtSecurityToken jwtAccessTokenObj);
    bool IsValidAccessToken(string AccessTokenStr);
    (JwtSecurityToken?, Exception?) GetJwtAccessTokenObjFromAccessTokenString(string AccessToken);
    (ClaimsPrincipal?, Exception?) GetClaimsPrinciple(string AccessToken);
    Task<(UserRefreshToken?, Exception?)> ValidateRefreshToken(int UserId, string AccessTokenStr, string RefreshTokenStr);
}
