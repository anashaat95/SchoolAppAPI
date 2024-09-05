namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    IQueryable<Student> GetAllStudents();
    IQueryable<Student> GetStudentById(int id);

}
