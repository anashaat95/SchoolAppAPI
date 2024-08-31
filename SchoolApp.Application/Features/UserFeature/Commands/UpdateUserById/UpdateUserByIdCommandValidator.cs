namespace SchoolApp.Application.Features.UserFeature.Commands.UpdateUserById;


public class AddUserCommandValidator : AbstractValidator<UpdateUserByIdCommand>
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
        RuleFor(x => x.UserData.FirstName).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.UserData.LastName).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.UserData.UserName).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.UserData.Email).ApplyCommonStringRules(5, 50).EmailAddress();
        RuleFor(x => x.UserData.PhoneNumber).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.UserData.Password).ApplyCommonStringRules(5, 50);
        RuleFor(x => x.UserData.ConfirmPassword).ApplyCommonStringRules(6, 50)
                                        .Equal(s => s.UserData.Password);
    }
    public void ApplyCustomValidationRules()
    {
    }
    #endregion
}
