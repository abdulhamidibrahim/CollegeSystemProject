using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IAttendanceRepo :IGenericRepo<Attendance>
{
    // add post specific functions here
    IEnumerable<Attendance>? GetStudentGroupAttendance(long groupId, long studentId);
}