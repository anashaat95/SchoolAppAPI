namespace SchoolApp.Application.Core.Features.StudentFeature.Queries;

public class GetSignleStudentByIdQueryRequest : IRequest<Response<GetSingleStudentByIdQueryResponse>>
{
    public GetSignleStudentByIdQueryRequest(int Id)
    {
        this.Id = Id;
    }
    [Required]
    public int Id { get; set; }
}
