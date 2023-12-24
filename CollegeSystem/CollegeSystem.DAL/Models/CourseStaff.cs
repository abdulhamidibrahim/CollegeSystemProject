using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class CourseStaff
{
    public int CourseStaffId { get; set; }
    
    public long? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Staff? Staff { get; set; }
}
