namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void GetStudentListMapping()
    {
        CreateMap<Student, GetStudentListQueryResponse>()
            .ForMember(
                dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.Name)
            );
    }
}
