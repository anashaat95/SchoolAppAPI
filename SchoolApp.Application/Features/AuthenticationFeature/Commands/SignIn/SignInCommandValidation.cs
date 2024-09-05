
namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.SignIn;

public class SignInCommandValidation:AbstractValidator<SignInCommand>
{
    #region Fields
    #endregion

    #region Constructor
    public SignInCommandValidation()
    {
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }

    #endregion


    #region Methods
    private void ApplyCustomValidationrules()
    {
        RuleFor(x => x.Username).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.Password).ApplyCommonStringRules(6, 50);
    }

    private void ApplyValidationrules()
    {
    }
    #endregion

}
