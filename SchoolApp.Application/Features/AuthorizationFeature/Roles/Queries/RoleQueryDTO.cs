namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

public class RoleQueryDTO
{
    public string Id { get; set; }
    public string Name { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleQueryDTO>();
        }
    }
}
