
using SchoolApp.Application.Services.AuthenticationService;
using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;

public class RefreshTokenCommandHandler : ResponseHandler,
    IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
{
    #region Field(s)
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;
    #endregion

    #region Constructor
    public RefreshTokenCommandHandler(IAuthenticationService authenticationService, IUserService userService, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _authenticationService = authenticationService;
        _userService = userService;
    }
    #endregion

    #region Handler
    public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // 1) Get JwtSecurityToken Object
        var (jwtAccessTokenObj, jwtAccessTokenEx) = _authenticationService.GetJwtAccessTokenObjFromAccessTokenString(request.AccessToken);
        if (jwtAccessTokenEx != null) return BadRequest<JwtAuthResult>("Invalid token");

        // 2) Get Claims Principle
        var (claimsPrinciple, claimsPrincipleEx) = _authenticationService.GetClaimsPrinciple(request.AccessToken);
        if (claimsPrincipleEx != null) return BadRequest<JwtAuthResult>("Invalid token");

        // 3) Get UserId
        var (userId, userIdEx) = _authenticationService.GetUserIdFromJwtAccessTokenObj(jwtAccessTokenObj!);              
        if (userIdEx != null) return BadRequest<JwtAuthResult>("Invalid token");

        // 4) Validate RefreshToken
        var (refreshTokenObj, refreshTokenEx) = await _authenticationService.ValidateRefreshToken(userId, request.AccessToken, request.RefreshToken);

        // 5) Get User
        var user = await _userService.GetUserById(userId).FirstOrDefaultAsync();
        if (user == null)
            return BadRequest<JwtAuthResult>("Invalid token");

        // 6) get new JwtAuth
        var jwtAuth = await _authenticationService.GetJwtAuthForuser(user);

        return Success(jwtAuth);
    }
    #endregion
}
