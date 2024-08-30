namespace SchoolApp.Application.Services.StudentService;

public class StudentService : IStudentService
{
    #region Fields
    private readonly IStudentRepository _repo;
    #endregion

    #region Constructors
    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }
    #endregion

    #region Action Methods
    public IQueryable<Student> GetAllStudents()
    {
        return _repo.GetAllStudents();
    }
    public IQueryable<Student> GetStudentById(int id)
    {
        return _repo.GetStudentById(id);
    }

    public IQueryable<Student> FilterStudentAndPaginate(StudentOrderingEnum[] OrderBy, string Search)
    {
        IQueryable<Student> queryable = _repo.GetTableNoTracking().Include(s => s.Department);

        // Filter by search criteria
        if (!string.IsNullOrEmpty(Search))
        {
            queryable = queryable.Where(x => x.Name.Contains(Search) ||
                                             x.Address.Contains(Search) ||
                                             x.Phone.Contains(Search));
        }

        //if (OrderBy == null || OrderBy.Length == 0) return queryable;

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

    public async Task<Student> AddAsync(Student student)
    {
        return await _repo.AddAsync(student);
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        return await _repo.UpdateAsync(student);
    }

    public async Task<bool> DeleteAsync(Student student)
    {
        using (var transaction = _repo.BeginTransaction())
        {
            try
            {
                await _repo.DeleteAsync(student);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                _repo.RollBack();
                return false;
            }
        }

    }

    public async Task<bool> IsNameExistAsync(string Name)
    {
        return (await _repo.GetTableNoTracking().Where(s => s.Name.Equals(Name)).FirstOrDefaultAsync()) != null;
    }

    public async Task<bool> IsNameExistExcludeSelfAsync(string Name, int Id)
    {
        return (await _repo.GetTableNoTracking().Where(s => !s.Id.Equals(Id) && s.Name.Equals(Name)).FirstOrDefaultAsync()) != null;
    }

    #endregion
}
