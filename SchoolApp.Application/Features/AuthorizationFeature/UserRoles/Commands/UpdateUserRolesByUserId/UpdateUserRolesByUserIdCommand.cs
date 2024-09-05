using SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;

public class UpdateUserRolesByUserIdCommand : IRequest<Response<string>>
{
    public int UserId { get; set; }
    public IEnumerable<string> Roles { get; set; }
}
