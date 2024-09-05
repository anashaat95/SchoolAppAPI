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
        RuleFor(s => s.StudentData.Name).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.StudentData.Address).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.StudentData.Phone).ApplyCommonStringRules(10, 50);
        RuleFor(s => s.StudentData.Phone).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
    public void ApplyCustomValidationrules()
    {

    }
    #endregion
}
