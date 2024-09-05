using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Application.Features.UserFeatrue.Commands.UpdateUserById;
public class UpdateUserByIdCommand : IRequest<Response<UserQueryDTO>>
{
    public int Id { get; set; }
    public UpdateUserByIdDTO UserData { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateUserByIdCommand, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserData.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.UserData.LastName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserData.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserData.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserData.Address))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.UserData.Country))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.UserData.PhoneNumber));
        }
    }
}