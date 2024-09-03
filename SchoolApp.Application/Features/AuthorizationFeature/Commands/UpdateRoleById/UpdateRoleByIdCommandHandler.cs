using Microsoft.VisualBasic;
using SchoolApp.Application.Features.AuthorizationFeature.Commands.UpdateRoleById;
using SchoolApp.Application.Features.AuthorizationFeature.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.Commands.UpdateRole;

public class UpdateRoleByIdCommandHandler : ResponseHandler,
    IRequestHandler<UpdateRoleByIdCommand, Response<RoleQueryDTO>>
{

    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public UpdateRoleByIdCommandHandler(IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
    }
    #endregion


    #region Method(s)
    public async Task<Response<RoleQueryDTO>> Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var mappedRole = _mapper.Map<Role>(request);
        var result = await _authorizationService.UpdateRoleAsync(mappedRole);
        if (result.Succeeded)
            return Success(_mapper.Map<RoleQueryDTO>(mappedRole));
        else return BadRequest<RoleQueryDTO>(result.Errors.FirstOrDefault().Description);
    }
    #endregion
}
