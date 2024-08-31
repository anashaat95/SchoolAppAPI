namespace SchoolApp.Application.Features.UserFeature.Commands.ChangeUserPasswordById;

public class ChangeUserPasswordByIdCommand : IRequest<Response<string>>
{
    public ChangeUserPasswordByIdCommand(int id, ChangeUserPasswordByIdDTO passwords)
    {
        Id = id;
        Passwords = passwords;
    }

    public int Id { get; set; }
    public ChangeUserPasswordByIdDTO Passwords { get; set; }
}