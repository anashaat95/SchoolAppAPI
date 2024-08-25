namespace SchoolApp.Application.Core.Features.StudentFeature.Queries.GetSignleStudentById;

public class GetSingleStudentByIdQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? DepartmentName { get; set; }
}
