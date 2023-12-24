using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class AllQuiz
{
    public long AllQuizzesId { get; set; }

    public string? Name { get; set; }

    public string? Instructor { get; set; }

    public string? MaxDegree { get; set; }

    public string? MaxTime { get; set; }

    public long? CourseId { get; set; }

    public virtual ICollection<ActiveAllQuiz> ActiveAllQuizzes { get; set; } = new List<ActiveAllQuiz>();

    public virtual ICollection<AllQuestion> AllQuestions { get; set; } = new List<AllQuestion>();

    public virtual ICollection<AnswerAllQuiz> AnswerAllQuizzes { get; set; } = new List<AnswerAllQuiz>();

    public virtual Course? Course { get; set; }
}
