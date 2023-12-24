
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class ActiveAllQuizRepo :GenericRepo<ActiveAllQuiz>, IActiveAllQuizRepo
{
    private readonly CollegeSystemDbContext _context;

    public ActiveAllQuizRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}