using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Assignment
{
    public long AssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string FileName { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;

    public Section? Section { get; set; } 
    public long? SectionId { get; set; }
    public virtual  ICollection<AssignmentAnswer> AssignmentAnswers { get; set; } = new List<AssignmentAnswer>();

    public Lecture? Lecture { get; set; } 
    public long? LectureId { get; set; }
    public Course? Course { get; set; } 
    public long? CourseId { get; set; }
}
