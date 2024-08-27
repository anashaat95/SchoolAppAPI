using SchoolApp.Application.Core.Wrappers;
using SchoolApp.Domain.Helpers;

namespace SchoolApp.Application.Core.Features.StudentFeature.Queries.GetStudentPaginatedList;

public class GetStudentPaginatedListQueryRequest : IRequest<PaginatedResult<GetStudentPaginatedListQueryResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrderingEnum[]? OrderBy { get; set; }
    public string? Search { get; set; }

}
