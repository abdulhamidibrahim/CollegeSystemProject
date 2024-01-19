namespace CollegeSystem.DL;

public class FileUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
}