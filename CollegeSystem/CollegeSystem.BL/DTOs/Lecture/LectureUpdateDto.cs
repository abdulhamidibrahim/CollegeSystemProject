namespace CollegeSystem.DL;

public class LectureUpdateDto
{
    public long LectureId { get; set; }

    public string? Title { get; set; }
    
    public long GroupId { get; set; }
}