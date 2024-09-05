namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommand : IRequest<Response<string>>
{
    public DeleteRoleByIdCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

}

