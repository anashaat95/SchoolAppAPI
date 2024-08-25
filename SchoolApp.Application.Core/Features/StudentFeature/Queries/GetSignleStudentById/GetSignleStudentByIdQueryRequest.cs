using MediatR;
using SchoolApp.Application.Core.Bases;
using SchoolApp.Application.Core.Features.StudentFeature.Queries.GetSignleStudentById;
using System.ComponentModel.DataAnnotations;

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
