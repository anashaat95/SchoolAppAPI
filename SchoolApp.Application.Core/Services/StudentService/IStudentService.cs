namespace SchoolApp.Application.Services.StudentService;

public interface IStudentService
{
    IQueryable<Student> FilterStudentAndPaginate(StudentOrderingEnum[] OrderBy, string Search);
    IQueryable<Student> GetStudentById(int id);
    IQueryable<Student> GetAllStudents();

    Task<Student> AddAsync(Student student);
    Task<bool> UpdateAsync(Student editedStudent);
    Task<bool> DeleteAsync(Student student);
    Task<bool> IsNameExistAsync(string Name);
    Task<bool> IsNameExistExcludeSelfAsync(string Name, int Id);
}