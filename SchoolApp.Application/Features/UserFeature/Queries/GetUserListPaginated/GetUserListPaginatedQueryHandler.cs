using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.UserFeatrue.Queries.GetUserList;

public class GetUserListPaginatedQueryHandler : ResponseHandler,
    IRequestHandler<GetUserListPaginatedQuery, PaginatedResult<UserQueryDTO>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly IUserService _service;
    #endregion

    #region Constructor(s)
    public GetUserListPaginatedQueryHandler(IUserService service, IMapper mapper, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _mapper = mapper;
        _service = service;

    }
    #endregion

    #region Handler
    public async Task<PaginatedResult<UserQueryDTO>> Handle(GetUserListPaginatedQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllUsers()
            .ProjectTo<UserQueryDTO>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
    #endregion
}
