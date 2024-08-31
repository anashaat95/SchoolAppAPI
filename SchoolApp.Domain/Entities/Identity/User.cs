namespace SchoolApp.Domain.Entities.Identity;

public class User : IdentityUser<int>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }

    public string FullName => FirstName + " " + LastName;
}
