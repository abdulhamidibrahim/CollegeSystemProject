
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AnswerRepo :GenericRepo<Answer>,IAnswerRepo
{
    private readonly CollegeSystemDbContext _context;

    public AnswerRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}