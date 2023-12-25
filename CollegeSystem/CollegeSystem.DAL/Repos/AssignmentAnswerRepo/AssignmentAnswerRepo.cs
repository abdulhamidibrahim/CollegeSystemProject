
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AssignmentAnswerRepo :GenericRepo<AssignmentAnswer>,IAssignmentAnswerRepo
{
    private readonly CollegeSystemDbContext _context;

    public AssignmentAnswerRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}