namespace CollegeSystem.DL;

public class AnswerUpdateDto
{
    public int AnswerId { get; set; }

    public string? StudentMark { get; set; } = string.Empty;

    public long? UserId { get; set; }

    public long? QuizId { get; set; }

    public long? CourseId { get; set; }

}
