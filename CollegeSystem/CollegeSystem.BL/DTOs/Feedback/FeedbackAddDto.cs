using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;
public class FeedbackAddDto
{
   
    public string? Content { get; set; }
    
    public DateTime? Date { get; set; }
    
    public long? LectureId { get; set; }
    
    public long? SectionId { get; set; }
    
    [Range(1,5,ErrorMessage = "Stars must be between 1 and 5")]
    public byte? Stars { get; set; }
    
    public long StudentId { get; set; }

}