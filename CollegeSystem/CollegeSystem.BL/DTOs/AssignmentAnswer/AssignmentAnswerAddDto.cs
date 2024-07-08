namespace CollegeSystem.DL;
public class AssignmentAnswerAddDto
{
    public long AssignmentId { get; set; }
    public long StudentId { get; set; } // Assuming this property exists
    public string FileName { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;
}

    

