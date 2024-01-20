using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class QuestionsRepo :GenericRepo<Question>,IQuestionRepo
{
    private readonly CollegeSystemDbContext _context;

    public QuestionsRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
    public List<Question> GetByQuizId(long quizId)
    {
        return _context.Questions!
            .Where(q => q.QuizId == quizId)
            .ToList();
    }
}