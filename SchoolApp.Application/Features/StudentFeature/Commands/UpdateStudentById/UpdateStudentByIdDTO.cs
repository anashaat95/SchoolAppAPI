
namespace SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudentById;

public class UpdateStudentByIdDTO
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required int DepartmentId { get; set; }
}
