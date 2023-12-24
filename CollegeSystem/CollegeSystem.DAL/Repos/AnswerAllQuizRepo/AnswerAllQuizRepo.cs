
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AnswerAllQuizRepo :GenericRepo<AnswerAllQuiz>,IAnswerAllQuizRepo
{
    private readonly CollegeSystemDbContext _context;

    public AnswerAllQuizRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}