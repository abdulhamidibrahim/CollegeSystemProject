namespace CollegeSystem.DL;

public class LectureFileDownloadDto
{
    public long Id { get; set; }
    // public long LectureId { get; set; }
    public string FileName { get; set; }
    // public string Description { get; set; }
    public byte[] FileData { get; set; } 

}