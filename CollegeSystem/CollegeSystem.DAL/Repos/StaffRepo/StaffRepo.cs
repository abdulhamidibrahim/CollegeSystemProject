using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class StaffRepo :GenericRepo<Staff>, IStaffRepo
{
    private readonly CollegeSystemDbContext _context;

    public StaffRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}