namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void EditStudentCommandMapping()
    {
        CreateMap<EditStudentCommandRequest, Student>();
    }
}
