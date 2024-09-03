using Microsoft.AspNetCore.Identity;

namespace SchoolApp.Application.Features.UserFeatrue.Commands.UpdateUserById;


public class UpdateUserCommandValidator : AbstractValidator<UpdateUserByIdCommand>
{
    #region Field(s)
    #endregion

    #region Constructor(s)
    public UpdateUserCommandValidator()
    {
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }
    #endregion

    #region Handler(s)
    public void ApplyValidationrules()
    {
        RuleFor(x => x.UserData.FirstName).ApplyCommonStringrules(5, 50);
        RuleFor(x => x.UserData.LastName).ApplyCommonStringrules(5, 50);
        RuleFor(x => x.UserData.UserName).ApplyCommonStringrules(5, 50);
        RuleFor(x => x.UserData.Email).ApplyCommonStringrules(5, 50).EmailAddress();
        RuleFor(x => x.UserData.PhoneNumber).ApplyCommonStringrules(5, 50);
        RuleFor(x => x.UserData.Password).ApplyCommonStringrules(5, 50);
        RuleFor(x => x.UserData.ConfirmPassword).ApplyCommonStringrules(6, 50)
                                        .Equal(s => s.UserData.Password);
    }
    public void ApplyCustomValidationrules()
    {
       
    }
    #endregion
}
