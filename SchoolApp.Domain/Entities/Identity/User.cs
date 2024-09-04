namespace SchoolApp.Domain.Entities.Identity;

public class User : IdentityUser<int>
{
    public User()
    {
        
    }
    public User(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }

    public ICollection<UserRefreshToken>? RefreshTokens { get; } = [];
    public ICollection<UserRole>? UserRoles { get; } = [];
    public ICollection<Role>? Roles { get; set; } = [];

    public string FullName => FirstName + " " + LastName;
}
