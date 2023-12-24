namespace CollegeSystem.DL;

public class LectureUpdateDto
{
    public long LectureId { get; set; }

    public string? Title { get; set; }

    public string? File { get; set; }

    public long? CourseId { get; set; }

}