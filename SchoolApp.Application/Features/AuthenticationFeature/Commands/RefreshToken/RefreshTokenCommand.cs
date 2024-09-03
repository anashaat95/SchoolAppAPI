namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
