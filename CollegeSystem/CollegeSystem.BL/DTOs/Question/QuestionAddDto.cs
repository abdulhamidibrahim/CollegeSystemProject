namespace CollegeSystem.DL;

public class QuestionAddDto
{
    public string QuestionText { get; set; } = string.Empty;
    public decimal Degree { get; set; }
    public virtual ICollection<OptionDto>? Options { get; set; }
    
}