using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Application.Features.UserFeatrue.Queries.GetUser;

public class GetUserByIdQuery : IRequest<Response<UserQueryDTO>>
{
    public int Id { get; set; }
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserQueryDTO>();
        }
    }
}
