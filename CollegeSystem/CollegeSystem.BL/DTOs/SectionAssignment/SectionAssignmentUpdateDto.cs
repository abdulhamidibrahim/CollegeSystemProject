namespace CollegeSystem.DL;

public class SectionAssignmentUpdateDto
{
    public long SectionAssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? CourseId { get; set; }

}       
