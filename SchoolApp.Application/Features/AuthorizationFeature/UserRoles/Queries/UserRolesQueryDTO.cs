namespace SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Queries;

public class UserRolesQueryDTO
{
    public int UserId { get; set; }
    public List<MiniRoleData> UserRoles { get; set; }

    public class MiniRoleData
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserRolesQueryDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles));
            CreateMap<Role, MiniRoleData>();
        }
    }
}
