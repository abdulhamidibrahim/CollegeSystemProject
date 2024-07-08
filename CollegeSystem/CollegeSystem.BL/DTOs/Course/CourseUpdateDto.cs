using CollegeSystem.BL.Enums;

namespace CollegeSystem.DL;

public class CourseUpdateDto
{
    public long CourseId { get; set; }

    public string? Name { get; set; }

    public Level? Level { get; set; }

    public Term? Term { get; set; }

    public Hours? Hours { get; set; }

    public string? Code { get; set; }
    
    public int? DeptId { get; set; }

    public string? Link { get; set; }
    
}       
