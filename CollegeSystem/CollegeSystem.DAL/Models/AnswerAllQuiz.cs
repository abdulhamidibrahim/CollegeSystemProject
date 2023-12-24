using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class AnswerAllQuiz
{
    public long AnswerAllQuizzesId { get; set; }

    public string? StudentMark { get; set; }
    
    public long? AllQuizzesId { get; set; }

    public long? CourseId { get; set; }

    public virtual AllQuiz? AllQuizzes { get; set; }

    public virtual Course? Course { get; set; }
    
    public virtual Student? Student { get; set; }

    
}
