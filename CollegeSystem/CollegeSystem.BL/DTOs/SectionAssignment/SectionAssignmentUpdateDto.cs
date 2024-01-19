using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class SectionAssignmentUpdateDto
{
    public long SectionAssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public File? File { get; set; }

    public long? CourseId { get; set; }

}       
