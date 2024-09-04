using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.AuthorizationFeature.Queries.GetUserRoles;

public class GetUserRolesQueryHandler : ResponseHandler,
    IRequestHandler<GetUserRolesQuery, Response<GetUserRolesQueryDTO>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    #endregion

    #region Field(s)
    public GetUserRolesQueryHandler(IAuthorizationService authorizationService, IUserService userService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _userService = userService;
        _mapper = mapper;
    }
    #endregion


    #region Handler
    public async Task<Response<GetUserRolesQueryDTO>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var userWithRoles = await _userService
            .GetUserById(request.UserId)
            .Select(u => new GetUserRolesQueryDTO
            {
                UserId = u.Id,
                UserRoles = u.Roles.Select(r => new GetUserRolesQueryDTO.MiniRoleData { RoleId = r.Id, Name = r.Name }).ToList()
            })
            .FirstOrDefaultAsync();


        if (userWithRoles == null) return NotFound<GetUserRolesQueryDTO>("No user found with the provided id");

        return Success<GetUserRolesQueryDTO>(userWithRoles);
    }
    #endregion
}
