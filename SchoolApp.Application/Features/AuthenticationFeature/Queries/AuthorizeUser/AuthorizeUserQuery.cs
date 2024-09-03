using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQuery : IRequest<Response<string>>
{
    public string AccessToken { get; set; }
}
