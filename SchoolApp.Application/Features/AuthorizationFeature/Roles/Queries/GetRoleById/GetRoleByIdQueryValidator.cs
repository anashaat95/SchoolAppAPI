namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
            .ApplyNotEmptyRule().ApplyNotNullableRule();
    }
}
