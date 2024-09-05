

using AutoMapper.QueryableExtensions;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommandHandler : ResponseHandler,
    IRequestHandler<DeleteRoleByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public DeleteRoleByIdCommandHandler(IAuthorizationService authorizationService, IMapper mapper, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
    }
    #endregion


    #region Method(s)
    public async Task<Response<string>> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _authorizationService.GetRoleById(request.Id)
                                                      .ProjectTo<Role>(_mapper.ConfigurationProvider)
                                                      .FirstOrDefaultAsync();
        if (existingRole == null) return NotFound<string>("Cannot delete the role because it was not found");

        try
        {
            var result = await _authorizationService.DeleteRoleAsync(existingRole);
            if (result.Succeeded) return Success("Deleted successfully");
            else return BadRequest<string>(result.ErrorsToString());
        }
        catch (Exception)
        {
            return NotFound<string>("Cannot delete the role because the role has users linked to it");
        }
    }
    #endregion
}
