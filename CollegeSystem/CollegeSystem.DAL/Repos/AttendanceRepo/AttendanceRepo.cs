using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AttendanceRepo :GenericRepo<Attendance>,IAttendanceRepo
{
    private readonly CollegeSystemDbContext _context;

    public AttendanceRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }


    public IEnumerable<Attendance>? GetStudentGroupAttendance(long groupId,long studentId)
    {
        return _context.Attendances.Where(p => p.GroupId == groupId && p.StudentId == studentId).ToList();
    }
   
}