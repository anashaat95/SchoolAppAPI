namespace SchoolApp.Infrastructrue.Data.EntitiesConfigurations;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("AspNetUserRoles", schema: "dbo");

        builder.HasKey(x => new { x.RoleId, x.UserId });

        builder
            .HasOne(x => x.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
