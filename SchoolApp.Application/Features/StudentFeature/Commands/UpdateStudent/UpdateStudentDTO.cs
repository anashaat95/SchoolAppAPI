namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudent;

public class UpdateStudentDTO
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required int DepartmentId { get; set; }
}
