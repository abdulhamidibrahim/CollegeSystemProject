namespace CollegeSystem.DL;

public class QuestionUpdateDto
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = string.Empty;
    public long? QuizId { get; set; }
    
    public virtual ICollection<OptionDto>? Options { get; set; }
    public decimal Degree { get; set; }
}       
