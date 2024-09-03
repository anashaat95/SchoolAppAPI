

namespace SchoolApp.Application.Features.AuthorizationFeatrue.Commands.DeleteRoleById;

public class DeleteRoleByIdCommandHandler : ResponseHandler,
    IRequestHandler<DeleteRoleByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IAuthorizationService _authorizationService;
    #endregion

    #region Constructor(s)
    public DeleteRoleByIdCommandHandler(IAuthorizationService authorizationService, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authorizationService = authorizationService;
    }
    #endregion


    #region Method(s)
    public async Task<Response<string>> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _authorizationService.GetRoleByIdAsync(request.Id);
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
