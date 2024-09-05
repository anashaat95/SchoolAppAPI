using SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUserByUserId;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUser;

public class AddRoleToUserByUserIdCommandValidator : AbstractValidator<AddRoleToUserByUserIdCommand>
{
    public AddRoleToUserByUserIdCommandValidator()
    {
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.UserId).ApplyNotEmptyRule().ApplyNotNullableRule();
        RuleFor(x => x.RoleName).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
}
