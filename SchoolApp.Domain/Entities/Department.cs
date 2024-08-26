namespace SchoolApp.Domain.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; } = [];
    public ICollection<Subject> Subjects { get; } = [];
    public ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
}
