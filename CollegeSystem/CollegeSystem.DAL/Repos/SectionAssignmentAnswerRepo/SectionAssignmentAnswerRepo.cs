
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class SectionAssignmentAnswerRepo :GenericRepo<SectionAssignmentAnswer>,ISectionAssignmentAnswerRepo
{
    private readonly CollegeSystemDbContext _context;

    public SectionAssignmentAnswerRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}