using SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRolesList;

public class GetRolesListQueryHandler : ResponseHandler,
    IRequestHandler<GetRolesListQuery, Response<List<RoleQueryDTO>>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    #endregion

    #region Field(s)
    public GetRolesListQueryHandler(IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
    }
    #endregion


    #region Handler
    public async Task<Response<List<RoleQueryDTO>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetRolesList()
                                               .ProjectTo<RoleQueryDTO>(_mapper.ConfigurationProvider)
                                               .ToListAsync();

        return Success(roles);
    }
    #endregion
}
