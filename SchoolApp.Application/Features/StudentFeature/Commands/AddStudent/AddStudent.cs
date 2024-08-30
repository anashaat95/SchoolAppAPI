namespace SchoolApp.Application.Features.StudentFeature.Commands.AddStudent;

public class AddStudentCommand : IRequest<Response<object>>
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required int DepartmentId { get; set; }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddStudentCommand, Student>();
        }
    }
}
