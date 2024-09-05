namespace SchoolApp.Domain.Entities;

public class Student : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public decimal Grade { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; } = null!;
    public ICollection<Subject> Subjects { get; } = [];
    public ICollection<StudentSubject> StudentSubjects { get; } = [];
}
