namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUser;

public class AddRoleToUserCommand : IRequest<Response<string>>    
{
    public int UserId {  get; set; }
    public string RoleName { get; set; }
}
