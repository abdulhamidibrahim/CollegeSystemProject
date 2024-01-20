using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Quiz
{
    public long QuizId { get; set; }

    public string? Name { get; set; }

    public string? Instructor { get; set; }

    public string? MaxDegree { get; set; }

    public string? MaxTime { get; set; }

    public long? LectureId { get; set; }
    public long? SectionId { get; set; }
    public long? CourseId { get; set; }

    public virtual ICollection<ActiveQuiz> ActiveQuizzes { get; set; } = new List<ActiveQuiz>();
    
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Course? Course { get; set; }
    public virtual Lecture? Lecture { get; set; }
    public virtual Section? Section { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
