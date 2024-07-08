using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.DAL.Models;

public partial class Question
{
    public int Id { get; set; }
    
    public string QuestionText { get; set; } = string.Empty;
    public long? QuizId { get; set; }

    [Precision(2)]
    public decimal Degree { get; set; }
    public virtual Quiz? Quiz { get; set; }
    
    public virtual ICollection<Option>? Options { get; set; }
}
