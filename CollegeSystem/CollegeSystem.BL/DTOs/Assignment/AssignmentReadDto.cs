namespace CollegeSystem.DL;
public class AssignmentReadDto
{
    public long Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }
    
    public DateTime? Deadline { get; set; }
    public bool IsSubmitted { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public string FileName { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;
}
public class AssignmentReadAllDto
{
    public long Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }
    
    public DateTime? Deadline { get; set; }
    public bool IsSubmitted { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    // public string FileName { get; set; } = string.Empty;
    // public byte[] FileContent { get; set; } = Array.Empty<byte>();
    // public string FileExtension { get; set; } = string.Empty;
}

