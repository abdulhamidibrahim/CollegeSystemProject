namespace CollegeSystem.DL;

public class AttendanceAddDto
{
    public bool Status { get; set; }=false;
    public string? QRCode { get; set; }
    public DateOnly Date { get; set; }
    public long StudentId { get; set; }
    public long GroupId { get; set; }

}
