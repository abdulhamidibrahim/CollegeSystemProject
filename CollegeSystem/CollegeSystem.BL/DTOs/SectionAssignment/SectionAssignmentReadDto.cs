using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class SectionAssignmentReadDto
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public File? File { get; set; }

    public long? CourseId { get; set; }

}