using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Question
{
    public int Id { get; set; }

    public string? Question1 { get; set; }

    public string? Answer { get; set; }

    public string? Choice1 { get; set; }

    public string? Choice2 { get; set; }

    public string? Choice3 { get; set; }

    public string? Choice4 { get; set; }

    public string? Choice5 { get; set; }

    public long? QuizId { get; set; }

    public virtual Quiz? Quiz { get; set; }
}
