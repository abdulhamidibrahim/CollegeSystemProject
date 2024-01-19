using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Lecture
{
    public long LectureId { get; set; }

    public string? Title { get; set; }

    public string? File { get; set; }

    public long? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    
    public virtual ICollection<LectureAssignment> LectureAssignments { get; set; } = new List<LectureAssignment>();
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();

    public virtual ICollection<TempAttendance> TempAttendances { get; set; } = new List<TempAttendance>();
}
