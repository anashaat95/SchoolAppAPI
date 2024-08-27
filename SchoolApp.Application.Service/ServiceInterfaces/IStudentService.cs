namespace SchoolApp.Application.Service.ServiceInterfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdWithIncludeAsync(int id);
    Task<Student> GetByIdAsync(int id);
    Task<string> AddAsync(Student student);
    Task<string> EditAsync(Student student);
    Task<string> DeleteAsync(Student student);
    Task<bool> IsNameExist(string Name);
    Task<bool> IsNameExistExcludeSelf(string Name, int Id);
}
