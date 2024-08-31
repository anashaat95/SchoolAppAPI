namespace School.API.Controllers;

[ApiController]
public class StudentController : AppControllerBase
{
    // GET api/<StudentController>
    [HttpGet(Router.StudentRouter.BASE)]
    public async Task<IActionResult> Get()
    {
        var response = await Mediator.Send(new GetStudentListQuery());
        return NewResult(response);
    }

    // GET api/<StudentController>/query
    [HttpGet(Router.StudentRouter.Query)]
    public async Task<IActionResult> GetPaginated([FromQuery] GetStudentPaginatedListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    // GET api/<StudentController>/{id}
    [HttpGet(Router.StudentRouter.ById)]
    public async Task<IActionResult> Get([FromRoute] int Id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(Id));
        return NewResult(response);
    }

    // POST api/<StudentController>/Create
    [HttpPost(Router.StudentRouter.BASE)]
    public async Task<IActionResult> Post([FromBody] AddStudentCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // PUT api/<StudentController>/{id}
    [HttpPut(Router.StudentRouter.ById)]
    public async Task<IActionResult> Put(int Id, [FromBody] UpdateStudentDTO data)
    {
        var response = await Mediator.Send(new UpdateStudentCommand { Id = Id, StudentData = data });
        return NewResult(response);
    }

    // DELETE api/<StudentController>/{id}
    [HttpDelete(Router.StudentRouter.ById)]
    public async Task<IActionResult> Delete([FromRoute] int Id)
    {
        var response = await Mediator.Send(new DeleteStudentCommand(Id));
        return NewResult(response);
    }
}
