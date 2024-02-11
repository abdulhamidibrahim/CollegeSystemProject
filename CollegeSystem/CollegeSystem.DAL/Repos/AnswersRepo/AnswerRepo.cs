
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

    public List<Answer>? GetAllQuizAnswers(long quizId)
    {
        return _context.Answers?
            .Where(x => x.QuizId == quizId)
            .ToList();
    }

    public List<Answer>? GetAllStudentAnswers(long studentId)
    {
        return _context.Answers?
            .Where(x => x.StudentId == studentId)
            .ToList();
    }
}