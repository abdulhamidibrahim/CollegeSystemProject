using System.Runtime.InteropServices.JavaScript;

namespace CollegeSystem.DAL.Models;

public class Attendance
{
    public long Id { get; set; }
    public bool Status { get; set; }=false;
    public string? QRCode { get; set; }
    public DateOnly Date { get; set; }
    public long StudentId { get; set; }
    public long GroupId { get; set; }
    public Student Student { get; set; }
    public Group Group { get; set; }
}