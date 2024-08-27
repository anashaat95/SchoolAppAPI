namespace SchoolApp.Application.Core.Features.StudentFeature.Commands;

public class AddStudentCommandRequest : IRequest<Response<string>>
{
    public string Name { get; set; }
    public string Phone {get; set;}
    public string Address {get; set;}
    public int DepartmentId {get; set;}
}
