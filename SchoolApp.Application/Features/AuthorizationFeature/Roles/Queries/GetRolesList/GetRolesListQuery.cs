using SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries.GetRolesList;

public class GetRolesListQuery : IRequest<Response<List<RoleQueryDTO>>>
{
}
