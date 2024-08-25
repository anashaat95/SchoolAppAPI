namespace SchoolApp.Domain.Entities;

public class DepartmentSubject
{
    public virtual required int Id { get; set; }
    public virtual required int SubjectId { get; set; }
    public virtual required int DepartmentId { get; set; }
    public virtual required Subject Subject { get; set; } = null!;
    public virtual required Department Department { get; set; } = null!;
}
