using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.DAL.Models;

public class Feedback
{
    public long Id { get; set; }
    public string? Content { get; set; }
    
    public DateTime? Date { get; set; }

    [ForeignKey(nameof(Lecture))]
    public long? LectureId { get; set; }
    public Lecture? Lecture { get; set; }

    [ForeignKey(nameof(Section))]
    public long? SectionId { get; set; }
    public Section? Section { get; set; }
    
    [Range(1,5,ErrorMessage = "Stars must be between 1 and 5")]
    public byte? Stars { get; set; }

    [ForeignKey(nameof(Student))]
    public long StudentId { get; set; }
    public virtual Student Student { get; set; }
    
}