namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        ApplyValidationrules();
    }

    public void ApplyValidationrules()
    {
        RuleFor(x => x.AccessToken).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
}
