using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? StudentMark { get; set; }

    public long? QuizId { get; set; }

    public long? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Quiz? Quiz { get; set; }
    
    public virtual Student? Student { get; set; }
    
}
