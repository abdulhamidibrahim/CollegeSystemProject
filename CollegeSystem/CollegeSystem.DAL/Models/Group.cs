using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.DAL.Models;

public class Group
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Course Course { get; set; }
    
    [ForeignKey(nameof(Course))]
    public long CourseId { get; set; }
    
    public ICollection<Lecture>? Lectures { get; set; } 
    
    public ICollection<Section>? Sections { get; set; } 
    public ICollection<Attendance>? Attendances { get; set; } 
    public ICollection<Assignment>? Assignments { get; set; } 
}