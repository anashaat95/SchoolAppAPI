namespace SchoolApp.Application.Features.UserFeature.Queries.GetUserList;

public class GetUserListPaginatedQueryHandler : ResponseHandler,
    IRequestHandler<GetUserListPaginatedQuery, PaginatedResult<UserQueryDTO>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    #endregion

    #region Constructor(s)
    public GetUserListPaginatedQueryHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;

    }
    #endregion

    #region Handler
    public async Task<PaginatedResult<UserQueryDTO>> Handle(GetUserListPaginatedQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users
            .ProjectTo<UserQueryDTO>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);

    }
    #endregion
}
