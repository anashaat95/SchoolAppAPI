using MediatR;
using SchoolApp.Application.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Application.Core.Features.StudentFeature.Commands;

public class AddStudentCommandRequest : IRequest<Response<string>>
{
    [Required(ErrorMessage = "The name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage ="The phone is required")]
    public string Phone {get; set;}
    [Required(ErrorMessage ="The address is required")]
    public string Address {get; set;}
    [Required(ErrorMessage = "The department id is required")]
    public int DepartmentId {get; set;}
}
