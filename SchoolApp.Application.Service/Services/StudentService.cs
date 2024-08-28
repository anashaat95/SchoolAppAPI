

using SchoolApp.Domain.Helpers;

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


    public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum[] OrderBy, string Search)
    {
        var queryable = _studentRepository.GetTableNoTracking()
                                          .Include(s => s.Department)
                                          .AsQueryable();

        // Filter by search criteria
        if (!string.IsNullOrEmpty(Search))
        {
            queryable = queryable.Where(x => x.Name.Contains(Search) ||
                                             x.Address.Contains(Search) ||
                                             x.Phone.Contains(Search));
        }

        if (OrderBy == null || OrderBy.Length == 0) return queryable;

        // Apply ordering
        IOrderedQueryable<Student> orderedQueryable = null;
        for (int i = 0; i < OrderBy.Length; i++)
        {
            switch (OrderBy[i])
            {
                case StudentOrderingEnum.Id:
                    orderedQueryable = i == 0 ? queryable.OrderBy(s => s.Id)
                                              : orderedQueryable.ThenBy(s => s.Id);
                    continue;
                case StudentOrderingEnum.Name:
                    orderedQueryable = i == 0 ? queryable.OrderBy(s => s.Name)
                                              : orderedQueryable.ThenBy(s => s.Name);
                    continue;
                case StudentOrderingEnum.Address:
                    orderedQueryable = i == 0 ? queryable.OrderBy(s => s.Address)
                                              : orderedQueryable.ThenBy(s => s.Address);
                    continue;
                case StudentOrderingEnum.Phone:
                    orderedQueryable = i == 0 ? queryable.OrderBy(s => s.Phone)
                                              : orderedQueryable.ThenBy(s => s.Phone);
                    continue;
                case StudentOrderingEnum.DepartmentId:
                    orderedQueryable = i == 0 ? queryable.OrderBy(s => s.DepartmentId)
                                              : orderedQueryable.ThenBy(s => s.DepartmentId);
                    continue;
                default:
                    continue;
            }
        }

        queryable = orderedQueryable ?? queryable;

        return queryable;
    }
    public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
    {
        return _studentRepository
            .GetTableNoTracking()
            .Include(s => s.Department)
            .Where(s => s.Id.Equals(id))
            .FirstOrDefault()!;
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
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
        return student != null;
    }

    public async Task<string> EditAsync(Student editedStudent)
    {
        try
        {
            await _studentRepository.UpdateAsync(editedStudent);
            return "Success";
        }
        catch (Exception)
        {
            return "Failure";
        }
    }

    public async Task<string> DeleteAsync(Student student)
    {
        using (var transaction = _studentRepository.BeginTransaction())
        {
            try
            {
                await _studentRepository.DeleteAsync(student);
                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception)
            {
                _studentRepository.RollBack();
            }
            return "Failure";
        }

    }

    #endregion
}
