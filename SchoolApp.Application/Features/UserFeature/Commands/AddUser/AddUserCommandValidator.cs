using SchoolApp.Application.Common.Validations;

namespace SchoolApp.Application.Features.UserFeature.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    #region Field(s)
    #endregion

    #region Constructor(s)
    public AddUserCommandValidator()
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Handler(s)
    public void ApplyValidationRules()
    {
        RuleFor(s => s.FirstName).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.LastName).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.UserName).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.Email).ApplyCommonStringRules(5, 50).EmailAddress();
        RuleFor(s => s.PhoneNumber).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.Password).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.ConfirmPassword).ApplyCommonStringRules(6, 50)
                                        .Equal(s => s.Password);
    }
    public void ApplyCustomValidationRules()
    {
    }
    #endregion
}