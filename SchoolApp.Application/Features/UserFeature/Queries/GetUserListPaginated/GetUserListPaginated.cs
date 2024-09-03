namespace SchoolApp.Application.Features.UserFeatrue.Queries.GetUserList;

public class GetUserListPaginatedQuery : IRequest<PaginatedResult<UserQueryDTO>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
