using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class AllQuizReadDto
{


    public string Name { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public string MaxDegree { get; set; } = string.Empty;
    public string MaxTime { get; set; } = string.Empty;
}

