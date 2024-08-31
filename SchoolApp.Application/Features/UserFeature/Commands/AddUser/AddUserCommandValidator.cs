using SchoolApp.Application.Common.Validations;
using System.Diagnostics;

namespace SchoolApp.Application.Features.UserFeature.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    #region Field(s)
    private UserManager<User> _userManager { get; set;  }
    #endregion

    #region Constructor(s)
    public AddUserCommandValidator(UserManager<User> userManager)
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
        _userManager = userManager;
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
        //RuleFor(x => x.Email)
        //    .MustAsync(async (Key, CancellationToken) => {
        //        return !(await _userManager.Users.AnyAsync(x => x.Email!.Equals(Key))); })
        //    .WithMessage($"A user with this email already exists. you can sign in or recover your password if you forgot");
    }
    #endregion
}