namespace CollegeSystem.DL;

public class UploadSectionFileDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
}