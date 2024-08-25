namespace SchoolApp.Domain.Entities;

public class Student
{
    public virtual required int Id { get; set; }
    public virtual required string Name { get; set; }
    public virtual required string Address { get; set; }
    public virtual required string Phone { get; set; }
    public virtual required int DepartmentId { get; set; }
    public virtual Department Department { get; } = null!;
    public virtual ICollection<Subject> Subjects { get; } = [];
    public virtual ICollection<StudentSubject> StudentSubjects { get; } = [];
}
