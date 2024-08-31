namespace SchoolApp.Application.Features.StudentFeature.Commands.DeleteStudentCommand;

public class DeleteStudentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteStudentCommand(int id)
    {
        Id = id;
    }
}
