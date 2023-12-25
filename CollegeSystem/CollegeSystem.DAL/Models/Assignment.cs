﻿using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Assignment
{
    public long AssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? CourseId { get; set; }

    public virtual ICollection<AssignmentAnswer> AssignmentAnswers { get; set; } = new List<AssignmentAnswer>();

    public virtual Course? Course { get; set; }
}