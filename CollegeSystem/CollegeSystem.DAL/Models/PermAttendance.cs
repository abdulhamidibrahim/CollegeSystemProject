using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class PermAttendance
{
    public long PermAttendanceId { get; set; }

    public int? Code { get; set; }

    public long? CourseId { get; set; }

    public long? SectionId { get; set; }

    public long LectureId { get; set; }
    
    public virtual Course? Course { get; set; }

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Section? Section { get; set; }

    public virtual Student? Student { get; set; }
}
