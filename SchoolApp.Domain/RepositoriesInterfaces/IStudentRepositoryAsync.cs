namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IStudentRepositoryAsync : IGenericRepositoryAsync<Student>
{
    Task<IEnumerable<Student>> GetStudentListAsync();
}
