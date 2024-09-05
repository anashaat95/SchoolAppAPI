
using SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.AddRoleToUser;
using SchoolApp.Application.Features.AuthorizationFeature.UserRoles.Commands.UpdateUserRolesByUserId;

namespace School.API.Controllers;

[ApiController]
public class UserRolesController : AppControllerBase
{
    // GET api/<UserController>/roles/{id}
    [HttpGet(Router.UserRouter.WithRoles.ById)]
    public async Task<IActionResult> GetUserWithRoles([FromRoute] int Id)
    {
        var response = await Mediator.Send(new GetUserRolesQuery(Id));
        return NewResult(response);
    }

    // POST api/<UserController>/Create
    [HttpPost((Router.UserRouter.WithRoles.BASE))]
    public async Task<IActionResult> Post([FromBody] AddRoleToUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // PUT api/<UserController>/roles/{id}
    [HttpPut(Router.UserRouter.WithRoles.ById)]
    public async Task<IActionResult> PutUserRoles(int Id, [FromBody] ICollection<string> data)
    {
        var response = await Mediator.Send(new UpdateUserRolesByUserIdCommand { UserId = Id, Roles = data });
        return NewResult(response);
    }
}
