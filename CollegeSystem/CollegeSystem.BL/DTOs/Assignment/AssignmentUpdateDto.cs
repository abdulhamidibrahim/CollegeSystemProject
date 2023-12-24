namespace CollegeSystem.DL;
public class AssignmentUpdateDto
{
    public long AssignmentId { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? CourseId { get; set; }
}

