
using SchoolApp.Application.Services.AuthenticationService;
using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.AuthenticationFeature.Commands.SignIn;

public class SignInCommandHandler : ResponseHandler,
    IRequestHandler<SignInCommand, Response<JwtAuthResult>>
{
    #region Field
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public SignInCommandHandler(IUserService userService, IAuthenticationService authService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userService = userService;
        _authService = authService;
        _mapper = mapper;
    }
    #endregion

    #region Handler
    public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByUserName(request.Username).FirstOrDefaultAsync();
        if (user == null || !await _userService.CheckPasswordAsync(user, request.Password))
            return BadRequest<JwtAuthResult>($"Invalid username and/or password");

        var JwtAuthResult = await _authService.GetJwtAuthForUser(user);

        return Success(JwtAuthResult);
    }
    #endregion
}
