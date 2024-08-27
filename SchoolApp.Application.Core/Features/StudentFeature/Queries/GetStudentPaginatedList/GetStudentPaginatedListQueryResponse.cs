namespace SchoolApp.Application.Core.Features.StudentFeature.Queries.GetStudentPaginatedList;

public class GetStudentPaginatedListQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string DepartmentName { get; set; }

    public GetStudentPaginatedListQueryResponse(int id, string name, string address, string departmentName)
    {
        Id = id;
        Name = name;
        Address = address;
        DepartmentName = departmentName;
    }
}
