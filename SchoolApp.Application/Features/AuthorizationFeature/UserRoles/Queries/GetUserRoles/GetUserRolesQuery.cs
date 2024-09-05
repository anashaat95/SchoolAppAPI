namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Queries.GetUserRoles;

public class GetUserRolesQuery : IRequest<Response<UserRolesQueryDTO>>
{
    public GetUserRolesQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
