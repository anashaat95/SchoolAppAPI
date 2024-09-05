using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;

class UpdateUserRolesByUserIdCommandHandler : ResponseHandler,
    IRequestHandler<UpdateUserRolesByUserIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    #endregion

    #region Field(s)
    public UpdateUserRolesByUserIdCommandHandler(IAuthorizationService authorizationService, IUserService userService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _userService = userService;
        _mapper = mapper;
    }
    #endregion


    #region Handler
    public async Task<Response<string>> Handle(UpdateUserRolesByUserIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserById(request.UserId).FirstOrDefaultAsync();

        if (user == null) return NotFound<string>("No user found with the provided id");

        user.UserRoles!.Clear();

        foreach (string roleName in request.Roles)
        {
            var role = await _authorizationService.GetRoleByName(roleName).FirstOrDefaultAsync();
            if (role == null)
                return NotFound<string>($"No role found with the provided name `{roleName}`");

            user.UserRoles.Add(new UserRole { Role = role});
        }

        var UpdateResult = await _userService.UpdateUserAsync(user);

        if (UpdateResult.Succeeded) return Success("Roles for this user updated succesfully");
        return BadRequest<string>(UpdateResult.ErrorsToString());
    }
    #endregion
}
