namespace SchoolApp.Infrastructrue.Data.EntitiesConfigurations;

public class SubjectConfig : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects", schema: "dbo");
        builder.HasKey(sub => sub.Id);
        builder.Property(sub => sub.Id).ValueGeneratedOnAdd();

        builder
            .Property(sub => sub.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(sub => sub.Period)
            .HasColumnName("Period")
            .IsRequired();

        builder.HasData(LoadSubjects());
    }

    public static List<Subject> LoadSubjects()
    {
        return new List<Subject>
        {
            new Subject {Id=1, Name="React", Period=1},
            new Subject {Id=2, Name="Math", Period=2},
        };
    }
}
