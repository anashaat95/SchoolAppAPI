namespace SchoolApp.Application.Features.AuthorizationFeature.Commands.AddRole;

public class AddRoleCommandHandler : ResponseHandler,
    IRequestHandler<AddRoleCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _roleService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public AddRoleCommandHandler(IAuthorizationService roleService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _roleService = roleService;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _roleService.AddRoleAsync(_mapper.Map<Role>(request));
        if (result.Succeeded) return Success("Added successfully");
        else return BadRequest<string>("Failed to add the role");
    }
    #endregion
}
