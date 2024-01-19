using System.ComponentModel.DataAnnotations;

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
    
    // public string? Phone { get; set; }  
    // public string? ParentEmail { get; set; }
    // public string? ParentPhone { get; set; }
    // public string? UniversityEmail { get; set; }
    // public string? Ssn { get; set; }
    
}