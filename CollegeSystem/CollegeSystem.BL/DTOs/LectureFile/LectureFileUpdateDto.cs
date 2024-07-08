namespace CollegeSystem.DL;

public class LectureFileUpdateDto
{
    public long Id { get; set; }
    public long LectureId { get; set; }
    public string FileName { get; set; }
    public byte[] FileData { get; set; } 
}