namespace CollegeSystem.DL;

public class QuestionReadDto
{
    public long Id { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public long? QuizId { get; set; }
    
    public virtual ICollection<OptionDto>? Options { get; set; }
    
}