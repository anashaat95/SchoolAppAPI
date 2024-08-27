﻿using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.API.Bases;
using SchoolApp.Application.Core.Features.StudentFeature.Commands;
using SchoolApp.Application.Core.Features.StudentFeature.Commands.EditStudentCommand;
using SchoolApp.Application.Core.Features.StudentFeature.Queries;
using SchoolApp.Application.Core.Features.StudentFeature.Queries.StudentListQuery;
using SchoolApp.Domain.AppMetaData;

namespace School.API.Controllers
{
    [Route("")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
        // GET api/<StudentController>/list
        [HttpGet(Router.StudentRoute.List)]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetStudentListQueryRequest());
            return NewResult(response);
        }

        // GET api/<StudentController>/5
        [HttpGet(Router.StudentRoute.GetById)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetSignleStudentByIdQueryRequest(id));
            return NewResult(response);
        }

        // POST api/<StudentController>/Create
        [HttpPost(Router.StudentRoute.Create)]
        public async Task<IActionResult> Post([FromBody] AddStudentCommandRequest command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        // PUT api/<StudentController>/Edit
        [HttpPut(Router.StudentRoute.Edit)]
        public async Task<IActionResult> Put([FromBody] EditStudentCommandRequest command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
