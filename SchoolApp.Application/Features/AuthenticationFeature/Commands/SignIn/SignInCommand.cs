namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.SignIn;

public class SignInCommand : IRequest<Response<JwtAuthResult>>
{
    public string Username { get; set; }
    public string Password { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SignInCommand, User>();
        }
    }
}
