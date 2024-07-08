using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Section
{
    public long SectionId { get; set; }

    public string? Title { get; set; }

    public long GroupId { get; set; }
    public Group Group { get; set; }
    // public long? GroupId { get; set; }

    public string? UploadedBy { get; set; }
    // public virtual CourseIe? Group { get; set; }
    
    public virtual Assignment? Assignment { get; set; }

    
    public virtual ICollection<File> Files { get; set; } = new List<File>();
    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();

    public virtual ICollection<TempAttendance> TempAttendances { get; set; } = new List<TempAttendance>();
    
}
