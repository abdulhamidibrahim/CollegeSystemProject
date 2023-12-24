namespace CollegeSystem.DL;

public class AllQuizUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public string MaxDegree { get; set; } = string.Empty;
    public string MaxTime { get; set; } = string.Empty;
}