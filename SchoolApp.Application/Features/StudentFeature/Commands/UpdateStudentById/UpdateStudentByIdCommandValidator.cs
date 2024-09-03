namespace SchoolApp.Application.Features.StudentFeatrue.Commands.UpdateStudentById;

public class UpdateStudentByIdCommandValidator : AbstractValidator<UpdateStudentByIdCommand>
{
    #region Fields
    private readonly IStudentService _studentService;
    #endregion

    #region Constructor(s)
    public UpdateStudentByIdCommandValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationrules();
        ApplyCustomValidationrules();
    }
    #endregion

    #region Action(s)
    public void ApplyValidationrules()
    {
        RuleFor(s => s.StudentData.Name).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.StudentData.Address).ApplyCommonStringrules(5, 50);
        RuleFor(s => s.StudentData.Phone).ApplyCommonStringrules(10, 50);
        RuleFor(s => s.StudentData.Phone).ApplyNotEmptyrule().ApplyNotNullablerule();
    }
    public void ApplyCustomValidationrules()
    {

    }
    #endregion
}
