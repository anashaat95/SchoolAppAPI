using Microsoft.AspNetCore.Authorization;
using SchoolApp.Application.Features.AuthorizationFeature.Commands.AddRole;
using SchoolApp.Application.Features.AuthorizationFeature.Commands.UpdateRoleById;

namespace School.API.Controllers;

//[Authorize(Roles = "ADMIN")]
//[Authorize(Roles = "USER")]
[ApiController]
public class AuthorizationController : AppControllerBase
{
    // GET api/<AuthorizationController>
    //[HttpGet(Router.AuthorizationRouter.RoleRouter.BASE)]
    //public async Task<IActionResult> Get()
    //{
    //    var response = await Mediator.Send(new GetStudentListQuery());
    //    return NewResult(response);
    //}

    // GET api/<AuthorizationController>/{id}
    //[HttpGet(Router.AuthorizationRouter.RoleRouter.ById)]
    //public async Task<IActionResult> Get([FromRoute] int Id)
    //{
    //    var response = await Mediator.Send(new GetStudentByIdQuery(Id));
    //    return NewResult(response);
    //}

    // POST api/<AuthorizationController>/Create
    [HttpPost(Router.AuthorizationRouter.RoleRouter.BASE)]
    public async Task<IActionResult> Post([FromQuery] AddRoleCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // PUT api/<AuthorizationController>/{id}
    [HttpPut(Router.AuthorizationRouter.RoleRouter.ById)]
    public async Task<IActionResult> Put(int Id, [FromBody] UpdateRoleByIdDTO data)
    {
        var response = await Mediator.Send(new UpdateRoleByIdCommand { Id = Id, RoleData = data });
        return NewResult(response);
    }

    // DELETE api/<AuthorizationController>/{id}
    //[HttpDelete(Router.AuthorizationRouter.RoleRouter.ById)]
    //public async Task<IActionResult> Delete([FromRoute] int Id)
    //{
    //    var response = await Mediator.Send(new DeleteStudentCommand(Id));
    //    return NewResult(response);
    //}

}
