namespace SchoolApp.Application.Features.UserFeature.Commands.ChangeUserPasswordById;


public class ChangeUserPasswordByIdCommandHandler : ResponseHandler,
    IRequestHandler<ChangeUserPasswordByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor(s)
    public ChangeUserPasswordByIdCommandHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    #endregion

    #region Handler(s)

    public async Task<Response<string>> Handle(ChangeUserPasswordByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(x => x.Id == request.Id)
                                           .FirstOrDefaultAsync();
        if (user == null)
            return NotFound<string>($"User with Id = {request.Id} is not found!");


        var result = await _userManager.ChangePasswordAsync(user, request.Passwords.CurrentPassword, request.Passwords.NewPassword);

        if (result.Succeeded) return Success<string>("Password updated successfully");
        else return BadRequest<string>(result.Errors.FirstOrDefault()!.Description);
    }
    #endregion
}
