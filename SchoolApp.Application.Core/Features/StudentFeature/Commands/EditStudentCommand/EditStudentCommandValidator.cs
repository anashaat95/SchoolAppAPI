using FluentValidation;
using SchoolApp.Application.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands.EditStudentCommand;

public class EditStudentCommandValidator:AbstractValidator<EditStudentCommandRequest>
{
    #region Fields
    private readonly IStudentService _studentService;
    #endregion

    #region Constructor(s)
    public EditStudentCommandValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Actions
    public void ApplyValidationRules()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(50).WithMessage("{PropertyName} must be less than or equal 50 characters");

        RuleFor(s => s.Address)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(50).WithMessage("{PropertyName} must be less than or equal 50 characters");
    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(s => s.Name)
            .MustAsync(async (Key, cancellationToken) => await _studentService.IsNameExist(Key)
            ).WithMessage("This field is required. {PropertyName} Exists");
    }
    #endregion
}
