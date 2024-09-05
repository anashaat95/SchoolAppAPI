namespace SchoolApp.Domain.Entities.Identity;

public class UserRole : IdentityUserRole<int>
{
    public new int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public new int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

}
