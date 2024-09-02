using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Domain.Helpers;

public class JwtAuthResult
{
    public string AccessToken { get; set; }

    public RefreshToken RefreshToken { get; set; }
}


public class RefreshToken
{
    public string Username { get; set; }
    public string Value { get; set; }
    public DateTime ExpiresAt { get; set; }
}