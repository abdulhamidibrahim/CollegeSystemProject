using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.DAL.Models;

[Table("Student")]
public partial class Student : ApplicationUser
{
    [Key()]
    public override required long Id { get; set; }
    
    [RegularExpression(@"^[0-9\u0600-\u06FF\s]+$", 
        ErrorMessage ="Enter Arabic characters and Numeric")]
    public string? ArabicName { get; set; }
    
    public string? UniversityEmail { get; set; }

    public DateTime EmailVerifiedAt { get; set; }

    public string? Password { get; set; }

    public string? Ssn { get; set; }

    public string? Img { get; set; }

    public string? Phone { get; set; }

    public string? ParentPhone { get; set; }

    public string? ParentEmail { get; set; }

    public int? DeptId { get; set; }

    public virtual ICollection<AnswerAllQuiz> AnswerAllQuizzes { get; set; } = new List<AnswerAllQuiz>();
    
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    
    public virtual ICollection<CourseUser> CourseUsers { get; set; } = new List<CourseUser>();
    
    public virtual Department? Dept { get; set; }
    
    public virtual ICollection<LectureAssignmentAnswer> LectureAssignmentAnswers { get; set; } = new List<LectureAssignmentAnswer>();
    
    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();
    
    public virtual ICollection<PostUser> PostUsers { get; set; } = new List<PostUser>();
    
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    
    public virtual ICollection<SectionAssignmentAnswer> SectionAssignmentAnswers { get; set; } = new List<SectionAssignmentAnswer>();
    
}
