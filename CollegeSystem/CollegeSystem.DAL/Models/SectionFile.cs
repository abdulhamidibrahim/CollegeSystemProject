namespace CollegeSystem.DAL.Models;

public class SectionFile
{
    public long Id { get; set; }
    public long SectionID { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public byte[] FileData { get; set; } // Storing the file data in the database
    public Section Section { get; set; }
}