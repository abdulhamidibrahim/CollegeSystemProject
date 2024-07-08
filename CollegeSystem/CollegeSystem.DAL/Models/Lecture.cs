using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.DAL.Models;

public partial class Lecture
{
    public long LectureId { get; set; }

    public string? Title { get; set; }

    // public long? GroupId { get; set; }
    public string? UploadedBy { get; set; }
    
    [ForeignKey(nameof(Group))]
    public long? GroupId { get; set; }

    public Group? Group { get; set; }
    // public virtual Group? Group { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    public virtual ICollection<PermAttendance> PermAttendances { get; set; } = new List<PermAttendance>();

    public virtual ICollection<TempAttendance> TempAttendances { get; set; } = new List<TempAttendance>();
}
