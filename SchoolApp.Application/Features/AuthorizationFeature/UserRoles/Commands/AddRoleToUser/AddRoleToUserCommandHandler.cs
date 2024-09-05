using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler : ResponseHandler,
    IRequestHandler<AddRoleToUserCommand, Response<string>>
{
    #region Fields
    private readonly IUserService _userService;
    private readonly IAuthorizationService _authorizationService;
    #endregion

    #region Constructor
    public AddRoleToUserCommandHandler(IUserService userService, IAuthorizationService authorizationService, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _userService = userService;
        _authorizationService = authorizationService;
    }
    #endregion

    #region Handler
    public async Task<Response<string>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserById(request.UserId).FirstOrDefaultAsync();
        if (user == null) return NotFound<string>($"No user found with the provided id `{request.UserId}`");

        var role = await _authorizationService.GetRoleByName(request.RoleName).FirstOrDefaultAsync();
        if (role == null) return NotFound<string>($"No role `{request.RoleName}` found");

        if (user.UserRoles != null && user.UserRoles.Any(ur=>ur.RoleId == role.Id))
            return Success($"User with Id `{request.UserId}` already has the role `{request.RoleName}`");

        var AddResult = await _userService.AddToRoleAsync(user, role);

        Console.WriteLine(AddResult);

        if (AddResult.Succeeded)
            return Success($"Role `{request.RoleName}` added successfull to user with id `{request.UserId}`");
        return BadRequest<string>(AddResult.ErrorsToString());
    }
    #endregion
}
