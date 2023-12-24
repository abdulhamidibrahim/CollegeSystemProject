using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class AssignmentAnswer
{
    public long AssignmentAnswerId { get; set; }

    public string? File { get; set; }

    public long? AssignmentId { get; set; }

    public virtual Assignment? Assignment { get; set; }
}
