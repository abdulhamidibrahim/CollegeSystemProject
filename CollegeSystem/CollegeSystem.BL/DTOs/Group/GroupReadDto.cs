using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class GroupReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long CourseId { get; set; }

}