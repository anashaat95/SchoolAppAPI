using AutoMapper.QueryableExtensions;
using SchoolApp.Application.Common.Models;
using SchoolApp.Application.Common.Resources;
using SchoolApp.Application.Common.ResponseBases;
using SchoolApp.Application.Services.StudentService;

namespace SchoolApp.Application.Features.StudentFeature.Queries.StudentListQuery;

public class GetStudentListQuery : IRequest<Response<IList<StudentQueryDTO>>>
{
}
