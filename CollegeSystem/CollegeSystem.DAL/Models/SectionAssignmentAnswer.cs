using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class SectionAssignmentAnswer
{
    public long SectionAssignmentAnswerId { get; set; }

    public string? File { get; set; }

    public long? SectionAssignmentId { get; set; }
    
    public virtual SectionAssignment? SectionAssignment { get; set; }

    public virtual Student? Student { get; set; }
}
