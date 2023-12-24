using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.BL.DTOs.User;

public class AdminLoginDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    
    [Required ]
    public string Password { get; set; } = string.Empty;
}