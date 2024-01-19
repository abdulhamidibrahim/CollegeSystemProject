using System.Diagnostics.CodeAnalysis;

namespace CollegeSystem.DAL.Models;

public class File
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
    
    public long? LectureId { get; set; }
    public Lecture Lecture { get; set; } = null!;

    public long? CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public long? StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public long? SectionId { get; set; }
    public Section Section { get; set; } = null!;
    
}