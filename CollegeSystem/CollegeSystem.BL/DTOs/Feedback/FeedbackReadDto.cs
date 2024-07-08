using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.DL;

public class FeedbackReadDto
{
    public long Id { get; set; }
    public string? Content { get; set; }
    
    public DateTime? Date { get; set; }
    
    public long? LectureId { get; set; }
    
    public long? SectionId { get; set; }
    
    [Range(1,5,ErrorMessage = "Stars must be between 1 and 5")]
    public byte? Stars { get; set; }
    
    public long StudentId { get; set; }
    public string? StudentName { get; set; }
}