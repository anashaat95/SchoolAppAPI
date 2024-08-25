using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoriesInterfaces;
using SchoolApp.Infrastructure.Data.Contexts;
using SchoolApp.Infrastructure.Data.Repositories.Bases;

namespace SchoolApp.Infrastructure.Data.Repositories;

public class StudentRepositoryAsync : GenericRepositoryAsync<Student>, IStudentRepositoryAsync
{
    #region Fields
    private readonly DbSet<Student> _students;
    #endregion

    #region Constructors
    public StudentRepositoryAsync(AppDbContext context) : base(context)
    {
        _students = _dbContext.Set<Student>();
    }
    #endregion

    #region Actions
    public async Task<IEnumerable<Student>> GetStudentListAsync()
    {
        return await _students.Include(s => s.Department).AsNoTracking().ToListAsync();
    }
    #endregion
}
