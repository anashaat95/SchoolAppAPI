using AutoMapper;

namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        GetStudentListMapping();
        GetSingleStudentByIdMapping();
    }
}
