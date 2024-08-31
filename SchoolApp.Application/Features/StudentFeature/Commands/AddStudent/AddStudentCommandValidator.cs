namespace SchoolApp.Application.Core.Features.StudentFeature.Commands.AddStudent;

public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    #region Fields
    private readonly IStudentService _service;
    #endregion

    #region Constructor(s)
    public AddStudentCommandValidator(IStudentService service)
    {
        _service = service;
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

        RuleFor(s => s.DepartmentId)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null");

    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(s => s.Name)
            .MustAsync(async (Key, cancellationToken) => !(await _service.IsNameExistAsync(Key))
            ).WithMessage("This field is required. {PropertyName} cannot be empty");
    }
    #endregion
}
