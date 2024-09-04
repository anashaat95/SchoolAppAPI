namespace SchoolApp.Domain.Entities.Identity;

public class Role : IdentityRole<int>
{
    public Role()
    {
        
    }
    public Role(string Name)
    {
        this.Name = Name;
    }
    public int Id {  get; set; }
    public ICollection<UserRole>? UserRoles { get; } = [];
    public ICollection<User>? Users { get;  } = [];
}
