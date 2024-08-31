using Microsoft.AspNetCore.Identity;
using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Application.Features.UserFeature.Commands.AddUser;

public class AddUserCommandHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    #endregion

    #region Constructor(s)
    public AddUserCommandHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var isExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email || x.UserName == request.UserName);
        if (isExists) return BadRequest<string>($"A user with the same username and/or email already exists. you can sign in rigt now!");

        var result = await _userManager.CreateAsync(_mapper.Map<User>(request), request.Password);

        if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault()!.Description);

        return Created<string>("Added Successfult");
    }
    #endregion
}
