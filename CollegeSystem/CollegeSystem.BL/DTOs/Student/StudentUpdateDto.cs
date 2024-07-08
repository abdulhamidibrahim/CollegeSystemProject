using CollegeSystem.BL.Enums;

namespace CollegeSystem.DL;

public class StudentUpdateDto
{
    public string Name { get; set; } =string.Empty;
    public string Email { get; set; } =string.Empty;
    public string UniversityEmail { get; set; } =string.Empty;
    public string Password { get; set; } =string.Empty;
    public string Ssn { get; set; } =string.Empty;
    public string Phone { get; set; } =string.Empty;
    public string Gender { get; set; } =string.Empty;
    public Level Level { get; set; }
    public Term Term { get; set; } 
    public string ParentPhone { get; set; } =string.Empty;
    public string ParentEmail { get; set; } =string.Empty;
}