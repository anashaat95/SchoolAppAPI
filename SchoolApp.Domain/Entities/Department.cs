namespace SchoolApp.Domain.Entities;

public class Department : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; } = [];
    public ICollection<Subject> Subjects { get; } = [];
    public ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
    public ICollection<Instructor> Instructors { get; } = [];
    public Instructor? Manager { get; set; }
}
