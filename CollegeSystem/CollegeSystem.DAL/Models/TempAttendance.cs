using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class TempAttendance
{
    public long TempAttendanceId { get; set; }

    public long? CourseId { get; set; }

    public long? SectionId { get; set; }

    public long? LectureId { get; set; }

    public string? X { get; set; }

    public string? Y { get; set; }

    public string? RandomCode { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual Section? Section { get; set; }
}
