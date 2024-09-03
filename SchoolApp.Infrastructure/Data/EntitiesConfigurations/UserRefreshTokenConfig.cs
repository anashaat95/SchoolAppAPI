using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Infrastructrue.Data.EntitiesConfigurations;

public class UserRefreshTokenConfig : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.ToTable("UserRefreshTokens", schema: "dbo");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        builder.Property(r => r.AccessToken)
            .HasColumnName("AccessToken")
            .HasColumnType("varchar(MAX)")
            .IsRequired(false);

        builder.Property(r => r.RefreshToken)
            .HasColumnName("RefreshToken")
            .HasColumnType("varchar(MAX)")
            .IsRequired(false);

        builder.Property(r => r.JwtId)
            .HasColumnName("JwtId")
            .HasColumnType("varchar(MAX)")
            .IsRequired(false);

        builder.Property(r => r.IsUsed)
            .HasColumnName("IsUsed")
            .HasColumnType("bit")
            .IsRequired(true);

        builder.Property(r => r.IsRevoked)
                .HasColumnName("IsRevoked")
                .HasColumnType("bit")
                .IsRequired(true);

        builder.Property(r => r.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(r => r.ExpiryDate)
            .HasColumnName("ExpiryDate")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.HasOne(r => r.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(r => r.UserId);
    }
}
