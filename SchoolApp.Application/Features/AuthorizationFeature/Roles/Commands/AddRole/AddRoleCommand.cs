using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.AddRole;

public class AddRoleCommand : IRequest<Response<string>>
{
    public string Name { get; set; }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddRoleCommand, Role>();
        }
    }
}
