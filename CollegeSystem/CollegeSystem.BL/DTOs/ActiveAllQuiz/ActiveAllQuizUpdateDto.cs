using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class ActivAllQuizUpdateDto
{


    public long ActiveAllQuizzesId { get; set; }

    public long? AllQuizzesId { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual AllQuiz? AllQuizzes { get; set; }
}
