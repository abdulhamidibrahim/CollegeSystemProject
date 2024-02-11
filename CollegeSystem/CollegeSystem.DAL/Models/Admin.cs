using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CollegeSystem.DAL.Models;

[Table("Admin")]
public class Admin: ApplicationUser
{
    [Required]
    [RegularExpression(@"^[\u0600-\u06FF\s]+$", 
        ErrorMessage ="Enter Arabic characters and Numeric")]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; }=string.Empty;
}