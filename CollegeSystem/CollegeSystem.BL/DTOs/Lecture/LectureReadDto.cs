using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class LectureReadDto
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? UploadedBy { get; set; }
    public ICollection<File>? Files { get; set; }

}