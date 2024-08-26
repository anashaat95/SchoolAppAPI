using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.Core.Bases;

namespace SchoolApp.API.Bases;

public class AppControllerBase : ControllerBase
{
    #region Fields
    private IMediator _mediateInstance;
    protected IMediator Mediator => _mediateInstance ??= HttpContext.RequestServices.GetService<IMediator>();
    #endregion

    public ObjectResult NewResult<T>(Response<T> response)
    {
        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                return new OkObjectResult(response);
            case System.Net.HttpStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case System.Net.HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);
            case System.Net.HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case System.Net.HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case System.Net.HttpStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case System.Net.HttpStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }
    }
}
