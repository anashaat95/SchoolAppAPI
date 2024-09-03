using SchoolApp.Application.Common.Resoruces;

namespace SchoolApp.Application.Common.ResponseBases;

public class ResponseHandler
{

    private readonly IStringLocalizer<SharedResoruces> _stringLocalizer;
    public ResponseHandler(IStringLocalizer<SharedResoruces> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }
    public Response<T> Deleted<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = Message == null ? _stringLocalizer[SharedResorucesKeys.Deleted] : Message
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = _stringLocalizer[SharedResorucesKeys.Success],
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = _stringLocalizer[SharedResorucesKeys.Unauthorized]
        };
    }
    public Response<T> BadRequest<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? _stringLocalizer[SharedResorucesKeys.BadRequest] : Message
        };
    }

    public Response<T> UnprocessableEntity<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = Message == null ? _stringLocalizer[SharedResorucesKeys.UnprocessableEntity] : Message
        };
    }

    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? _stringLocalizer[SharedResorucesKeys.NotFound] : message
        };
    }

    public Response<T> Created<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.Created,
            Succeeded = true,
            Message = _stringLocalizer[SharedResorucesKeys.Created],
            Meta = Meta
        };
    }
}
