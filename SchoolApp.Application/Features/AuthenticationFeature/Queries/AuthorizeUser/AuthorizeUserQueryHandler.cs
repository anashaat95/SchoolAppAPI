using SchoolApp.Application.Services.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQueryHandler : ResponseHandler,
    IRequestHandler<AuthorizeUserQuery, Response<string>>
{
    #region Field(s)
    private readonly IAuthenticationService _authService;
    #endregion

    #region Constructor(s)
    public AuthorizeUserQueryHandler(IAuthenticationService authService, IStringLocalizer<SharedResoruces> stringLocalizer) : base(stringLocalizer)
    {
        _authService = authService;
    }
    #endregion


    public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
    {
        if (_authService.IsValidAccessToken(request.AccessToken))
            return Success<string>("Valid");
        else return BadRequest<string>("Not valid");
        
    }
}
