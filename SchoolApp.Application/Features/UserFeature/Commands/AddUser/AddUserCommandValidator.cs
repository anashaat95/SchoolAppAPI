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
        RuleFor(s => s.FirstName).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.LastName).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.UserName).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.Email).ApplyCommonStringrules(5, 50).EmailAddress();
        RuleFor(s => s.PhoneNumber).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.Password).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.ConfirmPassword).ApplyCommonStringrules(6, 50)
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