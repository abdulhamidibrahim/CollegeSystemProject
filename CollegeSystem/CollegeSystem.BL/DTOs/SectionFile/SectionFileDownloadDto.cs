namespace CollegeSystem.DL;

public class SectionFileDownloadDto
{
    public long Id { get; set; }
    // public long SectionId { get; set; }
    // public string Description { get; set; }
    public string FileName { get; set; }
    public byte[] FileData { get; set; } 

}