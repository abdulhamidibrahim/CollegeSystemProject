
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class MeetingRepo :GenericRepo<Meeting>,IMeetingRepo
{
    private readonly CollegeSystemDbContext _context;

    public MeetingRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    

}