﻿using SchoolApp.Application.Features.UserFeatrue.Commands.UpdateUserById;

namespace SchoolApp.Application.Features.UserFeatrue.Commands.ChangeUserPasswordById;

public class ChangeUserPasswordByIdCommandValidator : AbstractValidator<ChangeUserPasswordByIdCommand>
{
    #region Field(s)
    #endregion

    #region Constructor(s)
    public ChangeUserPasswordByIdCommandValidator()
    {
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }
    #endregion

    #region Handler(s)
    public void ApplyValidationrules()
    {
        RuleFor(x => x.Passwords.CrurentPassword).ApplyCommonStringrules(6, 50);
        RuleFor(x => x.Passwords.NewPassword).ApplyCommonStringrules(6, 50);
        RuleFor(x => x.Passwords.ConfirmNewPassword).ApplyCommonStringrules(6, 50).Equal(x => x.Passwords.NewPassword);
    }
    public void ApplyCustomValidationrules()
    {

    }
    #endregion
}
