namespace CollegeSystem.DL;

public class PermAttendanceReadDto
{
    public long Id { get; set; }
    public int? Code { get; set; }

    public long? CourseId { get; set; }

    public long? SectionId { get; set; }

    public long LectureId { get; set; }

    public long? UserId { get; set; }

}