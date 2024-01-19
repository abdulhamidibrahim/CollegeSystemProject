
using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.BL.DTOs.User;

public class AdminRegisterDto
{
    
    
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = "Admin";
   
}