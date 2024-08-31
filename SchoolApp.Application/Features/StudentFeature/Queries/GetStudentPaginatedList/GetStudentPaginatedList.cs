namespace SchoolApp.Application.Features.StudentFeature.Queries.GetStudentPaginatedList;

public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<StudentQueryDTO>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public StudentOrderingEnum[]? OrderBy { get; set; }
    public string? Search { get; set; }
}
