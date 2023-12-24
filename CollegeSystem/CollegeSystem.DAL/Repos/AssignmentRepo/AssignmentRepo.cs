
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AssignmentRepo :GenericRepo<Assignment>,IAssignmentRepo
{
    private readonly CollegeSystemDbContext _context;

    public AssignmentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}