namespace CollegeSystem.DL;

public class UplaodLectureFileDto
{
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
    public long LectureId { get; set; }
}