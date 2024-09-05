using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Domain.Entities;

public class Instructor : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
    public Decimal Salary { get; set; }

    // Related to Specific Department
    public int DepartmentId {  get; set; }
    public Department Department { get; set; } = null!;

    
    // May manage a department
    public int? SupervisedDepartmentId { get; set; }
    public Department? SupervisedDepartment { get; set; } = null!;


    // Relation with Subject
    public ICollection<Subject> Subjects { get; } = [];
    public ICollection<InstructorSubject> InstructorSubjects { get; } = []; 

        
    // May manage one or more instructor
    public int? ManagerId { get; set; }
    public Instructor? Manager { get; set; } = null!;
    public ICollection<Instructor> ManagedInstructors { get; } = [];


}
