using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class LectureAssignment
{
    public long LectureAssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? LectureId { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual ICollection<LectureAssignmentAnswer> LectureAssignmentAnswers { get; set; } = new List<LectureAssignmentAnswer>();
}
