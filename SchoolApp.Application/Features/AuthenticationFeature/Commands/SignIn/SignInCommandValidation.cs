
namespace SchoolApp.Application.Features.AuthenticationFeature.Commands.SignIn;

public class SignInCommandValidation:AbstractValidator<SignInCommand>
{
    #region Fields
    #endregion

    #region Constructor
    public SignInCommandValidation()
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    #endregion


    #region Methods
    private void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Username).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.Password).ApplyCommonStringRules(6, 50);
    }

    private void ApplyValidationRules()
    {
    }
    #endregion

}
