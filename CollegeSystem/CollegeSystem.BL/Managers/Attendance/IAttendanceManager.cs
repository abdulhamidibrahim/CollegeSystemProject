namespace CollegeSystem.DL;

public interface IAttendanceManager
{
    //generate qrcode
    public byte[] GenerateQRCode(long groupId);
    public bool ValidateQRCode(string qrCode);
    //get student attendance 
        
    // public List<AttendanceReadDto> GetStudentAttendance(long studentId,long groupId);
    public void Add(AttendanceAddDto attendanceAddDto);
    public void Update(AttendanceUpdateDto attendanceUpdateDto);
    public void Delete(long id);
    public AttendanceReadDto? Get(long id);
    public List<AttendanceReadDto> GetAll(long groupId,long studnetId);
}