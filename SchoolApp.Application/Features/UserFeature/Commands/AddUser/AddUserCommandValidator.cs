using MediatR;
using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.UserFeatrue.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    #region Field(s)
    private readonly IUserService _service;
    #endregion

    #region Constructor(s)
    public AddUserCommandValidator(IUserService service)
    {
        _service = service;
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }
    #endregion

    #region Handler(s)
    public void ApplyValidationrules()
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
    public void ApplyCustomValidationrules()
    {
        RuleFor(x => new { Email = x.Email, UserName = x.UserName })
            .MustAsync(async (obj, CancellationToken) => !(await _service.IsUserExistsAsync(obj.Email, obj.UserName)))
            .WithMessage($"A user with the same username and/or email already exists. you can sign in rigt now!");
    }
    #endregion
}