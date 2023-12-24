using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class SectionAssignmentRepo :GenericRepo<SectionAssignment>,ISectionAssignmentRepo
{
    private readonly CollegeSystemDbContext _context;

    public SectionAssignmentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}