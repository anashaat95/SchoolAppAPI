namespace SchoolApp.Infrastructrue.Data.EntitiesConfigurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRole>
            (
                right => right.HasOne(ru => ru.Role).WithMany(u => u.UserRoles).HasForeignKey(ru => ru.RoleId).OnDelete(DeleteBehavior.Restrict),
                left => left.HasOne(ru => ru.User).WithMany(u => u.UserRoles).HasForeignKey(ru => ru.UserId).OnDelete(DeleteBehavior.Restrict),
                table =>
                {
                    table.HasKey(ru => new { ru.UserId, ru.RoleId });
                    table.ToTable("AspNetUserRoles", schema: "dbo");
                }
            ); 
    }
}
