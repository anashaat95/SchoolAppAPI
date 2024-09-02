using SchoolApp.Application.Features.AuthenticationFeature.Commands.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthenticationFeature.Queries.AuthorizeUser;

public class AuthorizeUserQueryValidator : AbstractValidator<AuthorizeUserQuery>
{

public AuthorizeUserQueryValidator()
{
    ApplyValidationRules();
}

public void ApplyValidationRules()
{
    RuleFor(x => x.AccessToken).ApplyNotEmptyRule().ApplyNotNullableRule();
}
}
