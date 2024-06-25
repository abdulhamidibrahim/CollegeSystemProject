namespace CollegeSystem.DL;

public class StudentReadDto
{
    public long Id { get; set; }
    public string? Name { get; set; } =string.Empty;
    public string? Email { get; set; } =string.Empty;
    public string? UniversityEmail { get; set; } =string.Empty;
    public string? Ssn { get; set; } =string.Empty;
    public string? Phone { get; set; } =string.Empty;
    public string Gender { get; set; } =string.Empty;
    public string Level { get; set; } =string.Empty;
    public string Term { get; set; } =string.Empty;
    public string? ParentPhone { get; set; } =string.Empty;
    public string? ParentEmail { get; set; } =string.Empty;
}