using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class QuizRepo :GenericRepo<Quiz>,IQuizRepo
{
    private readonly CollegeSystemDbContext _context;

    public QuizRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}