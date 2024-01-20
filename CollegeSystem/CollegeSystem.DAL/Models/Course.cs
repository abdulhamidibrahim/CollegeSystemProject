using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Course
{
    public long CourseId { get; set; }

    public string? Name { get; set; }

    public string? Level { get; set; }

    public string? Term { get; set; }

    public string? Hours { get; set; }

    public string? Code { get; set; }

    public string? Link { get; set; }

    public File? Img { get; set; }

    public virtual ICollection<AllQuiz> AllQuizzes { get; set; } = new List<AllQuiz>();

    public virtual ICollection<AnswerAllQuiz> AnswerAllQuizzes { get; set; } = new List<AnswerAllQuiz>();

    // public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<CourseStaff> CourseStaffs { get; set; } = new List<CourseStaff>();

    public virtual ICollection<CourseUser> CourseUsers { get; set; } = new List<CourseUser>();
    
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<TempAttendance> TempAttendances { get; set; } = new List<TempAttendance>();
}
