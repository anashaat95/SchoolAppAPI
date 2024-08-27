
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

    public async Task<bool> IsNameExist(string Name)
    { 
        return _studentRepository
            .GetTableNoTracking()
            .Where(s => s.Name.Equals(Name))
            .FirstOrDefault() != null;
    }

    public async Task<bool> IsNameExistExcludeSelf(string Name, int Id)
    {
        var student = _studentRepository
            .GetTableNoTracking()
            .Where(s => !s.Id.Equals(Id) && s.Name.Equals(Name))
            .FirstOrDefault();
        return  student != null;
    }

    public async Task<string> EditAsync(Student editedStudent)
    {
        try
        {
            await _studentRepository .UpdateAsync(editedStudent);
            return "Success";
        }
        catch (Exception)
        {
            return "Failure";
        }
    }

    #endregion
}
