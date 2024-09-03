namespace SchoolApp.Application.Features.UserFeature.Commands.DeleteUserById;

public class DeleteUserByIdCommandHandler : ResponseHandler,
    IRequestHandler<DeleteUserByIdCommand, Response<string>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    #endregion

    #region Field(s)
    public DeleteUserByIdCommandHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion


    #region Handler
    public async Task<Response<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(x => x.Id == request.Id)
                                           .FirstOrDefaultAsync();
        if (user == null)
            return NotFound<string>($"User with Id = {request.Id} is not found!");

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded) return Success("User deleted successfully");
        return BadRequest<string>("Failed to delete the user");
    }
    #endregion
}