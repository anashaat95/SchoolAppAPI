namespace SchoolApp.Application.Service.ServiceInterfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<string> AddAsync(Student student);
    Task<string> EditAsync(Student student);
    Task<bool> IsNameExist(string Name);
    Task<bool> IsNameExistExcludeSelf(string Name, int Id);
}
