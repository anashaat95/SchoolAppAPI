using System.Diagnostics;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands.EditStudentCommand;

public class EditStudentCommandValidator : AbstractValidator<EditStudentCommandRequest>
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

    #region Action(s)
    public void ApplyValidationRules()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 50 characters");

        RuleFor(s => s.Address)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 50 characters");
    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(s => s.Name)
            .MustAsync(async (model, Key, cancellationToken) =>
            {
                return !( await _studentService.IsNameExistExcludeSelf(Key, model.Id));
            }
            ).WithMessage("{PropertyName} is required. {PropertyName} Exists");
    }
    #endregion
}
