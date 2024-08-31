namespace SchoolApp.Application.Features.UserFeature.Queries.GetUser;

public class GetUserByIdQuery : IRequest<Response<UserQueryDTO>>
{
    public int Id { get; set; }
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserQueryDTO>();
        }
    }
}



public class GetUserByIdQueryHandler : ResponseHandler,
    IRequestHandler<GetUserByIdQuery, Response<UserQueryDTO>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    #endregion

    #region Constructor(s)
    public GetUserByIdQueryHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;

    }
    #endregion

    #region Handler
    public async Task<Response<UserQueryDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(x => x.Id == request.Id)
            .ProjectTo<UserQueryDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        if (user == null) return NotFound<UserQueryDTO>($"User with Id = {request.Id} is not found!");

        return Success<UserQueryDTO>(user);
    }
    #endregion
}
