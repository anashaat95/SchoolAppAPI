using SchoolApp.Application.Features.AuthenticationFeature.Commands.RefreshToken;
using SchoolApp.Application.Features.AuthenticationFeature.Commands.SignIn;
using SchoolApp.Application.Features.AuthenticationFeature.Queries.AuthorizeUser;

namespace School.API.Controllers;

[ApiController]
public class AuthenticationController : AppControllerBase
{
    // POST api/<AuthenticationController>/signin
    [HttpPost(Router.AuthenticationRouter.SignIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // POST api/<AuthenticationController>/refreshToken
    [HttpPost(Router.AuthenticationRouter.RefreshToken)]
    public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // POST api/<AuthenticationController>/refreshToken
    [HttpPost(Router.AuthenticationRouter.ValidateRefreshToken)]
    public async Task<IActionResult> ValidateRefreshToken([FromRoute] string token)
    {
        var response = await Mediator.Send(new AuthorizeUserQuery { AccessToken = token});
        return NewResult(response);
    }
}
