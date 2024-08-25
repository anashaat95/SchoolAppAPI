using SchoolApp.Application.Core.Features.StudentFeature.Queries.GetSignleStudentById;
using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchoolApp.Application.Core.Mapping.StudentMapping;

public partial class StudentProfile
{
    public void GetSingleStudentByIdMapping()
    {
        CreateMap<Student, GetSingleStudentByIdQueryResponse>()
            .ForMember(
                dest=>dest.DepartmentName,
                opt => opt.MapFrom(src=>src.Department.Name)
            );
    }
}
