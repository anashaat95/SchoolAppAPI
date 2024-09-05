namespace SchoolApp.Domain.Entities;

public class InstructorSubject : IEntity
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}
