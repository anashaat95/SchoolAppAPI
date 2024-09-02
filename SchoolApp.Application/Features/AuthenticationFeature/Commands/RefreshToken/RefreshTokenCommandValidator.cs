namespace SchoolApp.Application.Features.AuthenticationFeature.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        ApplyValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(x => x.AccessToken).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
}
