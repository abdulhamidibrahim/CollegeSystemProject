namespace CollegeSystem.DL;

public class AttendanceUpdateDto
{
    public long Id { get; set; }
    public bool Status { get; set; }=false;
    public string? QRCode { get; set; }
    public DateOnly Date { get; set; }
    public long StudentId { get; set; }
    public long CourseId { get; set; }
}
