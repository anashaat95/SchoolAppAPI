namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<Response<RoleQueryDTO>>
{
    public int Id { get; set; }
    public GetRoleByIdQuery(int id)
    {
        Id = id;
    }
}
