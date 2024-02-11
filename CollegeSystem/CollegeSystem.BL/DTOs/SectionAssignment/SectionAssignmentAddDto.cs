using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class SectionAssignmentAddDto
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Deadline { get; set; }

    public long? SectionId { get; set; }
    
}