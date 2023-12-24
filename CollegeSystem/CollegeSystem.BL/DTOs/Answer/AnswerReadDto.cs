namespace CollegeSystem.DL;

public class AnswerReadDto
{
    public string StudentMark { get; set; } = string.Empty;

    public long? UserId { get; set; }

    public long? QuizId { get; set; }

    public long? CourseId { get; set; }

}
