using MediatR;
using SchoolApp.Application.Core.Bases;
using SchoolApp.Application.Core.Features.StudentFeature.Queries.GetStudentListQuery;

namespace SchoolApp.Application.Core.Features.StudentFeature.Queries.StudentListQuery;

public class GetStudentListQueryRequest : IRequest<Response<IList<GetStudentListQueryResponse>>>
{
}
