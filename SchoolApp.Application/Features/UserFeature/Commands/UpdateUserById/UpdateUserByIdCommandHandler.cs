using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.UserFeatrue.Commands.UpdateUserById;

public class UpdateUserByIdCommandHandler : ResponseHandler,
        IRequestHandler<UpdateUserByIdCommand, Response<UserQueryDTO>>
{
    #region Field(s)
    private readonly IUserService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public UpdateUserByIdCommandHandler(IUserService service, IMapper mapper, IStringLocalizer<SharedResoruces> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)

    public async Task<Response<UserQueryDTO>> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _service.GetUser(request.Id, request.UserData.UserName, request.UserData.Password)
                                           .FirstOrDefaultAsync();
        if (user == null)
            return NotFound<UserQueryDTO>($"User with Id = {request.Id} is not found!");

        var mappedUser = _mapper.Map(request, user);
        var result = await  _service.UpdateUserAsync(_mapper.Map(request, user));

        if (result.Succeeded) return Success<UserQueryDTO>(_mapper.Map<UserQueryDTO>(mappedUser));
        else return BadRequest<UserQueryDTO>(result.ErrorsToString());
    }
    #endregion
}
