using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class ActiveQuiz
{
    public int ActiveQuizzesId { get; set; }

    public long? QuizId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? Duration { get; set; }

    public virtual Quiz? Quiz { get; set; }
}
