namespace SchoolApp.Domain.Entities;

public class StudentSubject : BaseEntity
{
    public  int SubjectId { get; set; }
    public  Subject Subject { get; set; } = null!;
    public  int StudentId { get; set; }
    public  Student Student { get; set; } = null!;
}
