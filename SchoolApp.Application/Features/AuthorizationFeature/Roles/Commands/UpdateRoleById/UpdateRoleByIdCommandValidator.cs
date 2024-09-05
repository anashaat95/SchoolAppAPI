namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.UpdateRoleById;

public class UpdateRoleByIdCommandValidator : AbstractValidator<UpdateRoleByIdCommand>
{
    #region Fields
    private IAuthorizationService _authorizationService { get; set; }
    #endregion

    #region Constructor(s)
    public UpdateRoleByIdCommandValidator(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        ApplyValidationRules();
        ApplyCustomValidationRoles();
    }
    #endregion

    #region Method(s)
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id).ApplyNotEmptyRule().ApplyNotNullableRule();
        RuleFor(x => x.RoleData.Name).ApplyCommonStringRules(3, 50);
    }

    public void ApplyCustomValidationRoles()
    {
        RuleFor(x => x.RoleData.Name)
            .MustAsync(async (Name, CancellationToken) => !await _authorizationService.IsRoleExistsAsync(Name))
            .WithMessage("This role name has been added before");
    }
    #endregion
}
