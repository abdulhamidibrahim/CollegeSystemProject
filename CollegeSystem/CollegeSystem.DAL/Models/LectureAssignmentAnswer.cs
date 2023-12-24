using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class LectureAssignmentAnswer
{
    public long LectureAssignmentAnswerId { get; set; }

    public string? File { get; set; }

    public long? LectureAssignmentId { get; set; }
    
    public virtual LectureAssignment? LectureAssignment { get; set; }

    public virtual Student? Student { get; set; }
}
