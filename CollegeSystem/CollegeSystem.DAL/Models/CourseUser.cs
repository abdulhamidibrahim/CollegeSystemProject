using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class CourseUser
{
    public long CourseUserId { get; set; }

    public string? Degree { get; set; }

    public long? CourseId { get; set; }
    public long? StudentId { get; set; }
    
    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
