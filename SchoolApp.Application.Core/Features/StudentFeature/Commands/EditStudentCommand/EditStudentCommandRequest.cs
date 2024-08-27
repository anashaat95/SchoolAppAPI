using MediatR;
using SchoolApp.Application.Core.Bases;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands.EditStudentCommand;

public class EditStudentCommandRequest : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int DepartmentId { get; set; }
}
