using SchoolApp.Application.Features.AuthenticationFeatrue.Commands.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQueryValidator : AbstractValidator<AuthorizeUserQuery>
{

public AuthorizeUserQueryValidator()
{
    ApplyValidationrules();
}

public void ApplyValidationrules()
{
    RuleFor(x => x.AccessToken).ApplyNotEmptyrule().ApplyNotNullablerule();
}
}
