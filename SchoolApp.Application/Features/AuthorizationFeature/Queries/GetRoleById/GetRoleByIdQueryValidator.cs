namespace SchoolApp.Application.Features.AuthorizationFeature.Queries.GetRoleById;

public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
            .ApplyNotEmptyrule().ApplyNotNullablerule();
    }
}
