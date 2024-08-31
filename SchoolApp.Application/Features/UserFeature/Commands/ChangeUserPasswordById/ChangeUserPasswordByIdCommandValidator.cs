using SchoolApp.Application.Features.UserFeature.Commands.UpdateUserById;

namespace SchoolApp.Application.Features.UserFeature.Commands.ChangeUserPasswordById;

public class ChangeUserPasswordByIdCommandValidator : AbstractValidator<ChangeUserPasswordByIdCommand>
{
    #region Field(s)
    #endregion

    #region Constructor(s)
    public ChangeUserPasswordByIdCommandValidator()
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Handler(s)
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Passwords.CurrentPassword).ApplyCommonStringRules(6, 50);
        RuleFor(x => x.Passwords.NewPassword).ApplyCommonStringRules(6, 50);
        RuleFor(x => x.Passwords.ConfirmNewPassword).ApplyCommonStringRules(6, 50).Equal(x => x.Passwords.NewPassword);
    }
    public void ApplyCustomValidationRules()
    {

    }
    #endregion
}
