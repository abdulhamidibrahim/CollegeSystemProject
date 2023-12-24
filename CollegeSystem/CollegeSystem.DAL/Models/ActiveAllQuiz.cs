using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class ActiveAllQuiz
{
    public long ActiveAllQuizzesId { get; set; }

    public long? AllQuizzesId { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual AllQuiz? AllQuizzes { get; set; }
}
