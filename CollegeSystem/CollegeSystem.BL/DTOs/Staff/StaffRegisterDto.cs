using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.DL;

public class StaffRegisterDto
{
    [Required]
    public string UserName { get; set; } = string.Empty; 
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = "Staff";
    public string RoleAssistant { get; set; } = "Assistant";
    public string RoleTeacher { get; set; } = "Teacher";
    
    [Required]
    public bool IsAssistant { get; set; } = false;


}