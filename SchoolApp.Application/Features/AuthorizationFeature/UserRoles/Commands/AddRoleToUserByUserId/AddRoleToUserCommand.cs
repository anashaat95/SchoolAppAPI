namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUserByUserId;

public class AddRoleToUserByUserIdCommand : IRequest<Response<string>>
{
    public int UserId { get; set; }
    public string RoleName { get; set; }
}
