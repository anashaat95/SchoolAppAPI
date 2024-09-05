using System.Security.Claims;

namespace SchoolApp.Domain.Helpers;

public static class ClaimsStore
{
    public static List<Claim> claims = new List<Claim>()
    {
        new Claim("Create Student", "false"),
        new Claim("Edit Student",   "false"),
        new Claim("Update Student", "false")
    };
}
