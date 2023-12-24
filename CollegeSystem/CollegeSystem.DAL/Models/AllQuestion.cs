using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class AllQuestion
{
    public long AllQuestionsId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public string? Choice1 { get; set; }

    public string? Choice2 { get; set; }

    public string? Choice3 { get; set; }

    public string? Choice4 { get; set; }

    public string? Choice5 { get; set; }

    public long? AllQuizzesId { get; set; }

    public virtual AllQuiz? AllQuizzes { get; set; }
}
