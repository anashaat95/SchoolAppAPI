namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudent;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    #region Fields
    private readonly IStudentService _studentService;
    #endregion

    #region Constructor(s)
    public UpdateStudentCommandValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Action(s)
    public void ApplyValidationRules()
    {
        RuleFor(s => s.StudentData.Name)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 50 characters");

        RuleFor(s => s.StudentData.Address)
            .NotEmpty().WithMessage("This field is required. {PropertyName} cannot be empty")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters")
            .MaximumLength(100).WithMessage("{PropertyName} must be less than or equal 50 characters");
    }
    public void ApplyCustomValidationRules()
    {

    }
    #endregion
}
