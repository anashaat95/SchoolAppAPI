namespace SchoolApp.Application.Features.AuthorizationFeatrue.Commands.AddRole;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{

    #region Fields
    private readonly IAuthorizationService _authorizationService;
    #endregion
    public AddRoleCommandValidator(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        ApplyValidationRules();
        ApplyCustomValidationRoles();
    }
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Name).ApplyNotEmptyrule().ApplyNotNullablerule();
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
