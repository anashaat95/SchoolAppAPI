namespace SchoolApp.Domain.Entities;

public class Subject  : IEntity
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public int Period { get; set; }
    public ICollection<Student> Students { get; } = [];
    public ICollection<Department> Departments { get; } = [];
    public ICollection<DepartmentSubject> DepartmentSubjects { get; } = [];
    public ICollection<StudentSubject> StudentSubjects { get; } = [];
    public ICollection<Instructor> Instructors { get; } = [];
    public ICollection<InstructorSubject> InstructorSubjects { get; } = [];
}
