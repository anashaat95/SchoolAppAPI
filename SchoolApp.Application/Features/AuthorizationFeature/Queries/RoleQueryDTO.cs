namespace SchoolApp.Application.Features.AuthorizationFeatrue.Queries;

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
