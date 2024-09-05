using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.AuthorizationFeature.Claims.GetClaims;

public class GetClaimsQuery : IRequest<Response<ClaimsQueryDTO>>
{
    public int Id { get; set; }
}
