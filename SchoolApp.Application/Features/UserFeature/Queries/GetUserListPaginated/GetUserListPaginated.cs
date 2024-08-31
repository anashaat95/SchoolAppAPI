namespace SchoolApp.Application.Features.UserFeature.Queries.GetUserList;

public class GetUserListPaginatedQuery : IRequest<PaginatedResult<UserQueryDTO>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
