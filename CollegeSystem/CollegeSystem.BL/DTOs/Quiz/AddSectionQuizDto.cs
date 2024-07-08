namespace CollegeSystem.DL;

public class AddSectionQuizDto
{
    public string? Name { get; set; }

    public string? Instructor { get; set; }

    public string? MaxDegree { get; set; }

    public string? MaxTime { get; set; }

    public long? SectionId { get; set; }
    public bool IsActive { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfQuestions { get; set; }
    public string? Description { get; set; }
}