namespace SchoolApp.Domain.Entities;

public class DepartmentSubject : BaseEntity
{
    public int SubjectId { get; set; }
    public int DepartmentId { get; set; }
    public Subject Subject { get; set; } = null!;
    public Department Department { get; set; } = null!;
}
