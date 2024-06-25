namespace CollegeSystem.DL;

public class AnswerReadDto
{
    public long Id { get; set; }
    public string StudentMark { get; set; } = string.Empty;

    public long? StudentId { get; set; }

    public long? QuizId { get; set; }


}
