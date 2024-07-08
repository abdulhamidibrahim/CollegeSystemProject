using CollegeSystem.DL;

namespace CollegeSystem.BL.DTOs.Submission;

public class SubmissionDto
{
    public int QuizId { get; set; }
    
    public long StudentId { get; set; }
    public ICollection<AnswerAddDto> Answers { get; set; }
}