
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
        return _context.ActiveQuizzes!
            .FirstOrDefault(q => q.QuizId == quizId);
    }

    public List<ActiveQuiz>? GetSectionsActiveQuiz()
    {
        return _context.ActiveQuizzes!
            .Where(q => q.Quiz!.SectionId != null)
            .ToList();
    }
    
    public List<ActiveQuiz>? GetLecturesActiveQuiz()
    {
        return _context.ActiveQuizzes!
            .Where(q => q.Quiz!.LectureId != null)
            .ToList();
    }
}