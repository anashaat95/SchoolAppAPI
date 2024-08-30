namespace SchoolApp.Infrastructure.Data.EntitiesConfigurations;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students", schema: "dbo");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder
            .Property(s => s.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(s => s.Address)
            .HasColumnName("Address")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();


        builder
            .Property(s => s.Phone)
            .HasColumnName("Phone")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


        builder
            .Property(s => s.Grade)
            .HasColumnName("Grade")
            .HasColumnType("decimal(18, 2)")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasOne(s => s.Department)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.DepartmentId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(s => s.Subjects)
            .WithMany(sub => sub.Students)
            .UsingEntity<StudentSubject>
            (
                left => left.HasOne(stSub => stSub.Subject).WithMany(sub => sub.StudentSubjects).HasForeignKey(stSub => stSub.SubjectId).OnDelete(DeleteBehavior.Restrict),
                right => right.HasOne(stSub => stSub.Student).WithMany(st => st.StudentSubjects).HasForeignKey(stSub => stSub.StudentId).OnDelete(DeleteBehavior.Restrict),
                table =>
                {
                    table.HasKey(stSub => new { stSub.SubjectId, stSub.StudentId });
                    table.ToTable("StudentSubjects", schema: "dbo");
                }
            );

        builder.HasData(LoadStudents());
    }

    public static List<Student> LoadStudents()
    {
        return new List<Student>
        {
        };
    }
}
