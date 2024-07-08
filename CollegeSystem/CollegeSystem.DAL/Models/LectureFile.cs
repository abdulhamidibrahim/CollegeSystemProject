namespace CollegeSystem.DAL.Models;

public class LectureFile
{
    public long Id { get; set; }
    public long LectureID { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public byte[] FileData { get; set; } // Storing the file data in the database
    public Lecture Lecture { get; set; }
}