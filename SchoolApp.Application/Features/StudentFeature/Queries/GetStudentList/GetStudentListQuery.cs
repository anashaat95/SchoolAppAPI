using AutoMapper.QueryableExtensions;
using SchoolApp.Application.Common.Models;
using SchoolApp.Application.Common.Resoruces;
using SchoolApp.Application.Common.ResponseBases;
using SchoolApp.Application.Services.StudentService;

namespace SchoolApp.Application.Features.StudentFeatrue.Queries.StudentListQuery;

public class GetStudentListQuery : IRequest<Response<IList<StudentQueryDTO>>>
{
}
