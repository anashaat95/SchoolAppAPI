namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler : ResponseHandler,
    IRequestHandler<GetRoleByIdQuery, Response<RoleQueryDTO>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    #endregion

    #region Field(s)
    public GetRoleByIdQueryHandler(IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
    }
    #endregion


    #region Handler
    public async Task<Response<RoleQueryDTO>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _authorizationService.GetRoleById(request.Id)
                                              .ProjectTo<RoleQueryDTO>(_mapper.ConfigurationProvider)
                                              .FirstOrDefaultAsync();
        if (role == null)
            return NotFound<RoleQueryDTO>("No role found with the provided id");
        else
            return Success(role);
    }
    #endregion
}
