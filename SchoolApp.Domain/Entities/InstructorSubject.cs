using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Domain.Entities;

public class InstructorSubject
{
    public int Id { get; set; } 
    public int SubjectId { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}
