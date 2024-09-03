namespace SchoolApp.Application.Features.AuthorizationFeature.Commands.AddRole;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{

    #region Fields
    private readonly IAuthorizationService _authorizationService;
    #endregion
    public AddRoleCommandValidator(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        ApplyValidationRoles();
        ApplyCustomValidationRoles();
    }
    public void ApplyValidationRoles()
    {
        RuleFor(x => x.Name).ApplyNotEmptyRule().ApplyNotNullableRule();
    }

    public void ApplyCustomValidationRoles()
    {
        RuleFor(x => x.Name)
            .MustAsync(async (Name, CancellationToken) =>
                !await _authorizationService.IsRoleExistsAsync(Name)
            )
            .WithMessage($"This role was added before");
    }
}
