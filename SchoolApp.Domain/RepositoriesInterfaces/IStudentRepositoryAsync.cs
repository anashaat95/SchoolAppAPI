using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoriesInterfaces.Bases;

namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IStudentRepositoryAsync : IGenericRepositoryAsync<Student>
{
    Task<IEnumerable<Student>> GetStudentListAsync();
}
