namespace SchoolApp.Application.Features.UserFeature.Commands.UpdateUserById;

public partial class UpdateStudentCommand
{
    public class UpdateUserByIdCommandHandler : ResponseHandler,
        IRequestHandler<UpdateUserByIdCommand, Response<UserQueryDTO>>
    {
        #region Field(s)
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public UpdateUserByIdCommandHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        #region Handler(s)

        public async Task<Response<UserQueryDTO>> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(x => x.Id == request.Id)
                                               .FirstOrDefaultAsync();
            if (user == null)
                return NotFound<UserQueryDTO>($"User with Id = {request.Id} is not found!");


            var mappedUser = _mapper.Map(request, user);
            var result = await _userManager.UpdateAsync(mappedUser);

            if (result.Succeeded) return Created<UserQueryDTO>(_mapper.Map<UserQueryDTO>(mappedUser));
            else return BadRequest<UserQueryDTO>();
        }
        #endregion
    }
}