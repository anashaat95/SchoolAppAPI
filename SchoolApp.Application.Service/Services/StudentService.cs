using Microsoft.EntityFrameworkCore;
using SchoolApp.Application.Service.ServiceInterfaces;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoriesInterfaces;

namespace SchoolApp.Application.Service.Services;

public class StudentService : IStudentService
{
    #region Fields
    private readonly IStudentRepositoryAsync _studentRepository;
    #endregion

    #region Constructors
    public StudentService(IStudentRepositoryAsync studentRepository)
    {
        _studentRepository = studentRepository;
    }
    #endregion

    #region Action Methods
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetStudentListAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return _studentRepository
            .GetTableNoTracking()
            .Include(s => s.Department)
            .Where(s => s.Id.Equals(id))
            .FirstOrDefault()!;
    }


    public async Task<string> AddAsync(Student student)
    {
        // Check if the name is Exist OR Not
        var retrievedStudent = _studentRepository
                                .GetTableNoTracking()
                                .Where(s => s.Name.Equals(student.Name))
                                .FirstOrDefault();
        if (retrievedStudent != null) return "Exist";

        // Add Student
        await _studentRepository.AddAsync(student);
        return "Success";

    }

    #endregion
}
