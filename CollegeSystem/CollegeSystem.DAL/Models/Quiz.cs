using System;
using System.Collections.Generic;
using CollegeSystem.BL.Enums;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.DAL.Models;

public partial class Quiz
{
    public long QuizId { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Instructor { get; set; }
    
    [Precision(2)]
    public decimal? MaxDegree { get; set; }

    public string? MaxTime { get; set; }
    public QuizType QuizType { get; set; } = 0;
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public bool IsActive { get; set; }
    public int NumberOfQuestions { get; set; }
    public long? GroupId { get; set; }
    public long? LectureId { get; set; }
    public long? SectionId { get; set; }

    public virtual ICollection<ActiveQuiz> ActiveQuizzes { get; set; } = new List<ActiveQuiz>();
    
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Lecture Lecture { get; set; }
    public virtual Section Section { get; set; }
    // public virtual Group Group { get; set; }
    public virtual Group Group { get; set; }
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
