using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CollegeSystem.DL;

public class UploadAssignmentFileDto
{
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
}