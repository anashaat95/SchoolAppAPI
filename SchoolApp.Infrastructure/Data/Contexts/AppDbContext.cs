using Microsoft.AspNetCore.Identity;
using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Infrastructrue.Data.Contexts;

public class AppDbContext : IdentityDbContext<User, Role, int,
                            IdentityUserClaim<int>, UserRole,
                            IdentityUserLogin<int>, IdentityRoleClaim<int>,
                            IdentityUserToken<int>>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);
    }
}
