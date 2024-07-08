namespace CollegeSystem.DL;

public class OptionDto
{
    
    public string OptionText { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int QuestionId { get; set; }
    //public virtual QuestionDto? Question { get; set; }
}