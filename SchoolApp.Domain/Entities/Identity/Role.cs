namespace SchoolApp.Domain.Entities.Identity;

public class Role : IdentityRole<int>
{
    public int Id {  get; set; }
    public ICollection<UserRole>? UserRoles { get; } = [];
    public ICollection<User>? Users { get;  } = [];
}
