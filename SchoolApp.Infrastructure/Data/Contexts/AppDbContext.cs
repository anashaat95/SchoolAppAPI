namespace SchoolApp.Infrastructure.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> StudentSubjects { get; set; }
    public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
    public DbSet<InstructorSubject> InstructorSubjects { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);
    }
}
