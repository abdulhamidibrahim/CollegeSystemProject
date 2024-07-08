using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using CollegeSystem.BL.Enums;

namespace CollegeSystem.DAL.Models;

public partial class Assignment
{
    public long AssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
    public bool IsSubmitted { get; set; }
    public AssignmentType Type { get; set; } = AssignmentType.lecture;

    // public string FileName { get; set; } = string.Empty;
    // public byte[] FileContent { get; set; } = Array.Empty<byte>();
    // public string FileExtension { get; set; } = string.Empty;
    //
    public DateTime? Deadline { get; set; }
    public DateTime? CreatedAt { get; set; }

    public Section? Section { get; set; } 
    public long? SectionId { get; set; }
    public virtual  ICollection<AssignmentAnswer> AssignmentAnswers { get; set; } = new List<AssignmentAnswer>();

    public Lecture? Lecture { get; set; } 
    public long? LectureId { get; set; }
    public Group? Group { get; set; } 
    
    [ForeignKey(nameof(Group))]
    public long? GroupId { get; set; }
    public virtual ICollection<AssignmentFile> AssignmentFiles { get; set; } = new List<AssignmentFile>();
   
}
