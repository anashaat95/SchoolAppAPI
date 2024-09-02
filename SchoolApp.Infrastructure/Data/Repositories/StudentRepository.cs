

namespace SchoolApp.Infrastructure.Data.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    #region Fields
    private new readonly DbSet<Student> _set;
    #endregion

    #region Constructors
    public StudentRepository(AppDbContext context) : base(context)
    {
        _set = context.Set<Student>();
    }
    #endregion

    #region Actions
    public IQueryable<Student> GetAllStudents()
    {
        return _set.Include(s => s.Department).AsNoTracking();
    }

    public IQueryable<Student> GetStudentById(int id)
    {
        return _set.Where(s => s.Id.Equals(id)).Include(s => s.Department);
    }
    #endregion
}
