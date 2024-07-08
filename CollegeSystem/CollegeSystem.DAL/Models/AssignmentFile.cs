using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CollegeSystem.DAL.Models;

[Table("AssignmentFile")]
public class AssignmentFile 
{
    public long  Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] Content { get; set; } = Array.Empty<byte>();
    public string Extension { get; set; } = string.Empty;
    public Assignment Assignment { get; set; }
    public long AssignmentId { get; set; }
}
