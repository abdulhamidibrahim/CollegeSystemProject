
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class ActiveQuizRepo :GenericRepo<ActiveQuiz>, IActiveQuizRepo
{
    private readonly CollegeSystemDbContext _context;

    public ActiveQuizRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
    public ActiveQuiz? GetByQuizId(long quizId)
    {
        return _context.ActiveQuizzes?
            .FirstOrDefault(x => x.QuizId == quizId);
    }
    
}