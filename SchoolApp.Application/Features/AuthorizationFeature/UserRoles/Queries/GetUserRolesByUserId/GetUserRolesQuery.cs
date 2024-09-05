namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Queries.GetUserRolesByUserId;

public class GetUserRolesByUserIdQuery : IRequest<Response<UserRolesQueryDTO>>
{
    public GetUserRolesByUserIdQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
