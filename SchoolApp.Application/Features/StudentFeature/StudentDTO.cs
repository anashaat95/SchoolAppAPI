namespace SchoolApp.Application.Features.StudentFeature;

public class StudentQueryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? DepartmentName { get; set; }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentQueryDTO>();
        }
    }
}
