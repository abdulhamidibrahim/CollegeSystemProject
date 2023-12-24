namespace CollegeSystem.DL;

public class TempAttendanceUpdateDto
{
    public long TempAttendanceId { get; set; }

    public long? CourseId { get; set; }

    public long? SectionId { get; set; }

    public long? LectureId { get; set; }

    public string? X { get; set; }

    public string? Y { get; set; }

    public string? RandomCode { get; set; }
}       
