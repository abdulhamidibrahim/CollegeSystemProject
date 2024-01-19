using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Section
{
    public long SectionsId { get; set; }

    public string? Title { get; set; }

    public long? CourseId { get; set; }

    public virtual Course? Course { get; set; }
    
    public virtual Assignment? Assignment { get; set; }

    
    public virtual ICollection<File> Files { get; set; } = new List<File>();
    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();

    public virtual ICollection<TempAttendance> TempAttendances { get; set; } = new List<TempAttendance>();
}
