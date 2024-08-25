namespace SchoolApp.Domain.Entities;

public class Subject
{
    public virtual required int Id { get; set; }
    public virtual required string Name { get; set; }
    public virtual required DateTime Period { get; set; }
    public virtual ICollection<Student> Students { get; } = [];
    public virtual ICollection<Department> Departments { get; } = [];
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
    public virtual ICollection<StudentSubject> StudentSubjects { get; } = [];
}
