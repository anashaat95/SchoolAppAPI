using SchoolApp.Application.Core.Features.StudentFeature.Commands;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void AddStudentCommandMapping()
    {
        CreateMap<AddStudentCommandRequest, Student>();
    }
}
