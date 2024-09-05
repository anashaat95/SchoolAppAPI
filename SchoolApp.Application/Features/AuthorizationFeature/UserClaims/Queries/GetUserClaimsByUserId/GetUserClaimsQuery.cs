namespace SchoolApp.Application.Features.AuthorizationFeature.UserClaims.Queries.GetUserClaimsByUserId;

public class GetUserClaimsByUserIdQuery : IRequest<Response<List<UserClaimsDTO>>>
{
    public int UserId { get; set; }
}
