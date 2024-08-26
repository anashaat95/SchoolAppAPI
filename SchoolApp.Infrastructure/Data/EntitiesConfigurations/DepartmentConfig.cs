using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infrastructure.Data.EntitiesConfigurations;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments", schema: "dbo");
        builder.HasKey(dept => dept.Id);
        builder.Property(dept => dept.Id).ValueGeneratedOnAdd();

        builder
            .Property(dept => dept.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();


        builder
            .HasMany(d => d.Subjects)
            .WithMany(sub => sub.Departments)
            .UsingEntity<DepartmentSubject>
            (
                left => left.HasOne(deptSub => deptSub.Subject).WithMany(sub => sub.DepartmentSubjects).HasForeignKey(deptSub => deptSub.SubjectId),
                right => right.HasOne(deptSub => deptSub.Department).WithMany(dept => dept.DepartmentSubjects).HasForeignKey(deptSub => deptSub.DepartmentId),
                table =>
                {
                    table.HasKey(deptSub => new { deptSub.SubjectId, deptSub.DepartmentId });
                    table.ToTable("DepartmentSubjects", schema: "dbo");
                }
            );

        builder.HasData(LoadDepartments());
    }

    public static List<Department> LoadDepartments()
    {
        return new List<Department>
        {
            new Department {Id=1, Name="Programming"},
            new Department {Id=2, Name="Data Science"},
        };
    }
}
