
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.DAL.Models;

[PrimaryKey(nameof(AssignmentAnswerId), nameof(StudentId))]
public partial class AssignmentAnswer
{
    
    // [Key]
    public long AssignmentAnswerId { get; set; }
    
    public long AssignmentId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
    public string FileExtension { get; set; } = string.Empty;


    public virtual Assignment Assignment { get; set; }
    
    public long StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
