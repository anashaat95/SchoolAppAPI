namespace SchoolApp.Domain.Entities;

public class DepartmentSubject : IEntity
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public int DepartmentId { get; set; }
    public Subject Subject { get; set; } = null!;
    public Department Department { get; set; } = null!;
}
