namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUser;

public class AddRoleToUserCommandValidator : AbstractValidator<AddRoleToUserCommand>
{
    public AddRoleToUserCommandValidator()
    {
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.UserId).ApplyNotEmptyRule().ApplyNotNullableRule();
        RuleFor(x => x.RoleName).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
}
