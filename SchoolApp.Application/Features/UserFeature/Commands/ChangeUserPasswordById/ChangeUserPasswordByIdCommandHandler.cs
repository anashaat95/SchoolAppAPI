using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application.Features.UserFeature.Commands.ChangeUserPasswordById;


public class ChangeUserPasswordByIdCommandHandler : ResponseHandler,
    IRequestHandler<ChangeUserPasswordByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IUserService _service;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public ChangeUserPasswordByIdCommandHandler(IUserService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _service = service;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)

    public async Task<Response<string>> Handle(ChangeUserPasswordByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _service.GetUserById(request.Id).FirstOrDefaultAsync();
        if (user == null)
            return NotFound<string>($"User with Id = {request.Id} is not found!");

        var result = await _service.ChangeUserPasswordAsync(user, request.Passwords.CurrentPassword, request.Passwords.NewPassword);

        if (result.Succeeded) return Success<string>("Password updated successfully");
        else return BadRequest<string>(result.ErrorsToString());
    }
    #endregion
}
