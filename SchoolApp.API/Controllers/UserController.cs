﻿using SchoolApp.Application.Features.UserFeature.Commands.AddUser;
using SchoolApp.Application.Features.UserFeature.Commands.DeleteUserById;
using SchoolApp.Application.Features.UserFeature.Commands.UpdateUserById;
using SchoolApp.Application.Features.UserFeature.Queries.GetUser;
using SchoolApp.Application.Features.UserFeature.Queries.GetUserList;

namespace School.API.Controllers;

[ApiController]
public class UserController : AppControllerBase
{
    // GET api/<UserController>/query
    [HttpGet(Router.UserRouter.Query)]
    public async Task<IActionResult> GetPaginated([FromQuery] GetUserListPaginatedQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    // GET api/<UserController>/{id}
    [HttpGet(Router.UserRouter.ById)]
    public async Task<IActionResult> Get([FromRoute] int Id)
    {
        var response = await Mediator.Send(new GetUserByIdQuery(Id));
        return NewResult(response);
    }

    // POST api/<UserController>/Create
    [HttpPost((Router.UserRouter.BASE))]
    public async Task<IActionResult> Post([FromBody] AddUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // PUT api/<UserController>/{id}
    [HttpPut(Router.UserRouter.ById)]
    public async Task<IActionResult> Put(int Id, [FromBody] UpdateUserByIdDTO data)
    {
        var response = await Mediator.Send(new UpdateUserByIdCommand { Id = Id, UserData = data });
        return NewResult(response);
    }

    // DELETE api/<UserController>/{id}
    [HttpDelete(Router.UserRouter.ById)]
    public async Task<IActionResult> Delete([FromRoute] int Id)
    {
        var response = await Mediator.Send(new DeleteUserByIdCommand(Id));
        return NewResult(response);
    }
}
