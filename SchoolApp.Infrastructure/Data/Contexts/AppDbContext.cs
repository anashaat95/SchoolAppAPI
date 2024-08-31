using Microsoft.AspNetCore.Identity;
using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Infrastructure.Data.Contexts;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int,
                            IdentityUserClaim<int>, IdentityUserRole<int>,
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
