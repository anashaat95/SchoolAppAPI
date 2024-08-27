namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void GetSingleStudentByIdMapping()
    {
        CreateMap<Student, GetSingleStudentByIdQueryResponse>()
            .ForMember(
                dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.Name)
            );
    }
}
