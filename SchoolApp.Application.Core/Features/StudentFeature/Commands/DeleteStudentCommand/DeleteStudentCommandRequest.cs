using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands.DeleteStudentCommand;

public class DeleteStudentCommandRequest : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteStudentCommandRequest(int id)
    {
        Id = id;
    }
}
