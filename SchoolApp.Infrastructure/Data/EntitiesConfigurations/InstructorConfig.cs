
using Microsoft.Data.SqlClient;

namespace SchoolApp.Infrastructure.Data.EntitiesConfigurations;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors", schema: "dbo");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.Name)
            .HasColumnName("Name").HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(i => i.Address)
            .HasColumnName("Address").HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(i => i.Position)
            .HasColumnName("Position").HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(i => i.Salary)
            .HasColumnName("Salary").HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(i => i.Department)
            .WithMany(dept => dept.Instructors)
            .HasForeignKey(i => i.DepartmentId)
            .IsRequired(true);

        builder.HasOne(i => i.SupervisedDepartment)
            .WithOne(dept => dept.Manager)
            .HasForeignKey<Instructor>(i=>i.SupervisedDepartmentId)
            .IsRequired(false);

        builder.HasOne(i => i.Manager)
            .WithMany(m => m.ManagedInstructors)
            .HasForeignKey(i => i.ManagerId)
            .IsRequired(false);

        builder.HasMany(i => i.Subjects)
            .WithMany(s => s.Instructors)
            .UsingEntity<InstructorSubject>
            (
                left => left.HasOne(inSub => inSub.Subject).WithMany(s => s.InstructorSubjects).HasForeignKey(inSub => inSub.SubjectId),
                right => right.HasOne(inSub => inSub.Instructor).WithMany(i => i.InstructorSubjects).HasForeignKey(inSub => inSub.InstructorId),
                table =>
                {
                    table.HasKey(inSub => new { inSub.SubjectId, inSub.InstructorId });
                    table.ToTable("InstructorSubjects", schema: "dbo");
                }
            );

    }
}
