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
    
    public Quiz? GetByLectureId(long lectureId)
    {
        return _context.Quizzes?
            .FirstOrDefault(q => q.LectureId == lectureId);
    }
    
    public Quiz? GetBySectionId(long sectionId)
    {
        return _context.Quizzes?
            .FirstOrDefault(q => q.SectionId == sectionId);
    }
    public List<Quiz>? GetAll(long courseId)
    {
        return _context.Quizzes?
            .Where(q => q.CourseId == courseId)
            .ToList();
    }
   
    
    public List<Quiz>? GetAllSectionQuizzes(long courseId)
    {
        return _context.Quizzes?
            .Where(q => q.CourseId == courseId && q.SectionId != null)
            .ToList();
    }
    
    public List<Quiz>? GetAllLectureQuizzes(long courseId)
    {
        return _context.Quizzes?
            .Where(q => q.CourseId == courseId && q.LectureId != null)
            .ToList();
    }
}