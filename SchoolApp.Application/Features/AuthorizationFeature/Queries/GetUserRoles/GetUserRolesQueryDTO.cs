using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthorizationFeature.Queries.GetUserRoles;

public class GetUserRolesQueryDTO
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
            CreateMap<User, GetUserRolesQueryDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.Roles));
            CreateMap<Role, MiniRoleData>();
        }
    }
}
