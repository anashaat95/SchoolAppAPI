using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Service.ServiceInterfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<string> AddAsync(Student student);
    Task<bool> IsNameExist(string Name);
}
