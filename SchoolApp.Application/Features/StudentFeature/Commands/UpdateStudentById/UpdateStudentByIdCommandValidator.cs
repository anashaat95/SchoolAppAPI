namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudentById;

public class UpdateStudentByIdCommandValidator : AbstractValidator<UpdateStudentByIdCommand>
{
    #region Fields
    private readonly IStudentService _studentService;
    #endregion

    #region Constructor(s)
    public UpdateStudentByIdCommandValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Action(s)
    public void ApplyValidationRules()
    {
        RuleFor(s => s.StudentData.Name).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.StudentData.Address).ApplyCommonStringRules(5, 50);
        RuleFor(s => s.StudentData.Phone).ApplyCommonStringRules(10, 50);
        RuleFor(s => s.StudentData.Phone).ApplyNotEmptyRule().ApplyNotNullableRule();
    }
    public void ApplyCustomValidationRules()
    {

    }
    #endregion
}
