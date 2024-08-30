namespace School.API.Controllers;

[Route("")]
[ApiController]
public class StudentController : AppControllerBase
{
    // GET api/<StudentController>/list
    [HttpGet(Router.StudentRoute.BASE)]
    public async Task<IActionResult> Get()
    {
        var response = await Mediator.Send(new GetStudentListQuery());
        return NewResult(response);
    }

    // GET api/<StudentController>/list
    [HttpGet(Router.StudentRoute.Paginated)]
    public async Task<IActionResult> GetPaginated([FromQuery] GetStudentPaginatedListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    // GET api/<StudentController>/5
    [HttpGet(Router.StudentRoute.ById)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(id));
        return NewResult(response);
    }

    // POST api/<StudentController>/Create
    [HttpPost(Router.StudentRoute.BASE)]
    public async Task<IActionResult> Post([FromBody] AddStudentCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    // PUT api/<StudentController>/Edit
    [HttpPut(Router.StudentRoute.ById)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentDTO data)
    {
        var response = await Mediator.Send(new UpdateStudentCommand { Id = id, StudentData = data });
        return NewResult(response);
    }

    // DELETE api/<StudentController>/5
    [HttpDelete(Router.StudentRoute.ById)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await Mediator.Send(new DeleteStudentCommand(id));
        return NewResult(response);
    }
}
