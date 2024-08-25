using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.Core.Features.StudentFeature.Queries;
using SchoolApp.Application.Core.Features.StudentFeature.Queries.GetSignleStudentById;
using SchoolApp.Application.Core.Features.StudentFeature.Queries.StudentListQuery;
using SchoolApp.Domain.AppMetaData;

namespace School.API.Controllers
{
    [Route("")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<StudentController>/list
        [HttpGet(Router.StudentRoute.List)]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetStudentListQueryRequest());
            return Ok(response);
        }

        // GET api/<StudentController>/5
        [HttpGet(Router.StudentRoute.GetById)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetSignleStudentByIdQueryRequest(id));
            return Ok(response);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
