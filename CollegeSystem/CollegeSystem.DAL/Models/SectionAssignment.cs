using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class SectionAssignment
{
    public long SectionAssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? SectionId { get; set; }

    public virtual Section? Section { get; set; }

    public virtual ICollection<SectionAssignmentAnswer> SectionAssignmentAnswers { get; set; } = new List<SectionAssignmentAnswer>();
}
