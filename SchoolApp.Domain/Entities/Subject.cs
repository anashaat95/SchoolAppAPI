namespace SchoolApp.Domain.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Period { get; set; }
    public ICollection<Student> Students { get; } = [];
    public ICollection<Department> Departments { get; } = [];
    public ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
    public ICollection<StudentSubject> StudentSubjects { get; } = [];
}
