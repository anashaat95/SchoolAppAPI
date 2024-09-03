namespace SchoolApp.Application.Features.AuthorizationFeatrue.Commands.AddRole;

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
