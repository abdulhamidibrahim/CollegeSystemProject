
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class TempAttendanceRepo :GenericRepo<TempAttendance>,ITempAttendanceRepo
{
    private readonly CollegeSystemDbContext _context;

    public TempAttendanceRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}