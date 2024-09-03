namespace SchoolApp.Application.Features.AuthorizationFeatrue.Commands.UpdateRole;

public class UpdateRoleByIdCommandHandler : ResponseHandler,
    IRequestHandler<UpdateRoleByIdCommand, Response<RoleQueryDTO>>
{

    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public UpdateRoleByIdCommandHandler(IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
    }
    #endregion


    #region Method(s)
    public async Task<Response<RoleQueryDTO>> Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _authorizationService.GetRoleByIdAsync(request.Id);
        if (existingRole == null)
            return NotFound<RoleQueryDTO>("Cannot update the role because there is no role with the provided id");

        var mappedRole = _mapper.Map(request, existingRole);

        var result = await _authorizationService.UpdateRoleAsync(mappedRole!);
        if (result.Succeeded)
            return Success(_mapper.Map<RoleQueryDTO>(mappedRole));
        else return BadRequest<RoleQueryDTO>(result.ErrorsToString());
    }
    #endregion
}
