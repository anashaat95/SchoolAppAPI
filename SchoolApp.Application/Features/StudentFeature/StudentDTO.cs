namespace SchoolApp.Application.Features.StudentFeatrue;

public class StudentQueryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? DepartmentName { get; set; }

    public StudentQueryDTO() { }

    public StudentQueryDTO(int id, string name, string address, string departmentName)
    {
        Id = id;
        Name = name;
        Address = address;
        DepartmentName = departmentName;
    }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentQueryDTO>();
        }
    }
}
