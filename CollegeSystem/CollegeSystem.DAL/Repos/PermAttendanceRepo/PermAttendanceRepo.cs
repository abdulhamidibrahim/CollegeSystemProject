using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class PermAttendanceRepo :GenericRepo<PermAttendance>,IPermAttendanceRepo
{
    private readonly CollegeSystemDbContext _context;

    public PermAttendanceRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}