using System.ComponentModel.DataAnnotations;
using CollegeSystem.BL.Enums;

namespace CollegeSystem.DL;

public class StudentRegisterDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    // public string Role { get; set; } = "Student";

    public string? Phone { get; set; }  
    public Level? Level { get; set; }
    public Term? Term { get; set; }
    public string? Gender { get; set; }
    public string? Ssn { get; set; }

}