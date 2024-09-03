namespace SchoolApp.Application.Core.Features.StudentFeatrue.Commands.AddStudent;

public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    #region Fields
    private readonly IStudentService _service;
    #endregion

    #region Constructor(s)
    public AddStudentCommandValidator(IStudentService service)
    {
        _service = service;
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }
    #endregion

    #region Actions
    public void ApplyValidationrules()
    {
        RuleFor(s => s.Name).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.DepartmentId).ApplyNotEmptyrule().ApplyNotNullablerule();
    }
    public void ApplyCustomValidationrules()
    {
        RuleFor(s => s.Name)
            .MustAsync(async (Name, cancellationToken) => !(await _service.IsNameExistAsync(Name))
            ).WithMessage("A student with the same Name is already present!");
    }
    #endregion
}
