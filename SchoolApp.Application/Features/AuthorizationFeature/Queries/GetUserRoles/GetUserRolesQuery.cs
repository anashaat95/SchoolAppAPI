namespace SchoolApp.Application.Features.AuthorizationFeature.Queries.GetUserRoles;

public class GetUserRolesQuery : IRequest<Response<GetUserRolesQueryDTO>>
{
    public GetUserRolesQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; set; }
}
