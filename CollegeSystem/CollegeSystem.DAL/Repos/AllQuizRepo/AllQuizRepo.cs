
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AllQuizRepo :GenericRepo<AllQuiz>,IAllQuizRepo
{
    private readonly CollegeSystemDbContext _context;

    public AllQuizRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}