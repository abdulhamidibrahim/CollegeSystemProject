namespace CollegeSystem.DL;

public class QuizUpdateDto
{
    public long QuizId { get; set; }

    public string? Name { get; set; }

    public string? Instructor { get; set; }

    public string? MaxDegree { get; set; }

    public string? MaxTime { get; set; }

    public long? CourseId { get; set; }
}       
