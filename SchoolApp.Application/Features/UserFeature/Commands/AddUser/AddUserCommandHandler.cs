using Microsoft.AspNetCore.Identity;
using SchoolApp.Application.Services.UserService;
using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Application.Features.UserFeature.Commands.AddUser;

public class AddUserCommandHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>
{
    #region Field(s)
    private readonly IMapper _mapper;
    private readonly IUserService _service;
    #endregion

    #region Constructor(s)
    public AddUserCommandHandler(IUserService service, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _mapper = mapper;
        _service = service;
    }
    #endregion

    #region Handler(s)
    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.AddNewUserAsync(_mapper.Map<User>(request), request.Password);

        if (!result.Succeeded) return BadRequest<string>(result.ErrorsToString());
        return Created<string>("Added Successfult");
    }
    #endregion
}
