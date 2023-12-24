
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AllQuestionsRepo :GenericRepo<AllQuestion>,IAllQuestionRepo
{
    private readonly CollegeSystemDbContext _context;

    public AllQuestionsRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}