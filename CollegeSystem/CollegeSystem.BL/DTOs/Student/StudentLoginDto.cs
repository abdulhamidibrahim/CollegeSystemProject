using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.DL;

public class StudentLoginDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;

    
}