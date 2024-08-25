namespace SchoolApp.Domain.Entities;

public class StudentSubject
{
    public virtual required int Id { get; set; }
    public virtual required int SubjectId { get; set; }
    public virtual required Subject Subject { get; set; } = null!;
    public virtual required int StudentId { get; set; }
    public virtual required Student Student { get; set; } = null!;
}
