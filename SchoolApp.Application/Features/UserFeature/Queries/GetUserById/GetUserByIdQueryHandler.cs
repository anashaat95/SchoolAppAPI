using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.UserFeatrue.Queries.GetUser;

public class GetUserByIdQueryHandler : ResponseHandler,
    IRequestHandler<GetUserByIdQuery, Response<UserQueryDTO>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly IUserService _service;
    #endregion

    #region Constructor(s)
    public GetUserByIdQueryHandler(IUserService service, IMapper mapper, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _mapper = mapper;
        _service = service;

    }
    #endregion

    #region Handler
    public async Task<Response<UserQueryDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _service.GetUserById(request.Id)
                                .ProjectTo<UserQueryDTO>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync();

        if (user == null) return NotFound<UserQueryDTO>($"User with Id = {request.Id} is not found!");
        return Success<UserQueryDTO>(user);
    }
    #endregion
}
