namespace SchoolApp.Domain.Entities;

public class Department
{
    public virtual required int Id { get; set; }
    public virtual required string Name { get; set; }
    public virtual ICollection<Student> Students { get; } = [];
    public virtual ICollection<Subject> Subjects { get; } = [];
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
}
