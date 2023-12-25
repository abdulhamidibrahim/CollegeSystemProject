namespace CollegeSystem.DL;
public class StudentAddDto
{
    public long StudentCode { get; set; }
    public string Name { get; set; } =string.Empty;
    public string Email { get; set; } =string.Empty;
    public string UniversityEmail { get; set; } =string.Empty;
    public string Password { get; set; } =string.Empty;
    public string Ssn { get; set; } =string.Empty;
    public string Img { get; set; } =string.Empty;
    public string Phone { get; set; } =string.Empty;
    public string ParentPhone { get; set; } =string.Empty;
    public string ParentEmail { get; set; } =string.Empty;
}