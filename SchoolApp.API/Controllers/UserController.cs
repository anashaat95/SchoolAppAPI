using SchoolApp.Application.Features.UserFeature.Commands.AddUser;

namespace School.API.Controllers;

[ApiController]
public class UserController : AppControllerBase
{
    //// GET api/<UserController>
    //[HttpGet("/")]
    //public async Task<IActionResult> Get()
    //{
    //    var response = await Mediator.Send(new GetStudentListQuery());
    //    return NewResult(response);
    //}

    //// GET api/<UserController>/query
    //[HttpGet(Router.Query)]
    //public async Task<IActionResult> GetPaginated([FromQuery] GetStudentPaginatedListQuery query)
    //{
    //    var response = await Mediator.Send(query);
    //    return Ok(response);
    //}

    //// GET api/<UserController>/{id}
    //[HttpGet(Router.ById)]
    //public async Task<IActionResult> Get([FromRoute] int Id)
    //{
    //    var response = await Mediator.Send(new GetStudentByIdQuery(Id));
    //    return NewResult(response);
    //}

    // POST api/<UserController>/Create
    [HttpPost((Router.UserRouter.BASE))]
    public async Task<IActionResult> Post([FromBody] AddUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    //// PUT api/<UserController>/{id}
    //[HttpPut(Router.ById)]
    //public async Task<IActionResult> Put(int Id, [FromBody] UpdateStudentDTO data)
    //{
    //    var response = await Mediator.Send(new UpdateStudentCommand { Id = Id, StudentData = data });
    //    return NewResult(response);
    //}

    //// DELETE api/<UserController>/{id}
    //[HttpDelete(Router.ById)]
    //public async Task<IActionResult> Delete([FromRoute] int Id)
    //{
    //    var response = await Mediator.Send(new DeleteStudentCommand(Id));
    //    return NewResult(response);
    //}
}
