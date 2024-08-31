namespace SchoolApp.Application.Features.StudentFeature.Queries.GetStudentById;

public record GetStudentByIdQuery : IRequest<Response<StudentQueryDTO>>
{
    public GetStudentByIdQuery(int Id)
    {
        this.Id = Id;
    }
    [Required]
    public int Id { get; set; }
}
