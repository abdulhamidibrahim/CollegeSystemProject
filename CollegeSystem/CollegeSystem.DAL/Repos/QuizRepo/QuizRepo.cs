using CollegeSystem.BL.Enums;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

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
    public List<Quiz>? GetAll(long groupId)
    {
        return _context.Quizzes?
            .Include(x => x.Section)
            .ThenInclude(x => x.Group)
            .Where(q => q.Section != null && q.Section.GroupId == groupId).ToList();
    }
   
    
    public List<Quiz>? GetAllSectionQuizzes(long groupId)
    {
        return _context.Quizzes?
            .Where(q => q.GroupId == groupId && q.QuizType == QuizType.section)
            .ToList();
    }
    
    public List<Quiz>? GetAllLectureQuizzes(long groupId)
    {
        return _context.Quizzes?
            .Where(q => q.GroupId == groupId && q.QuizType == QuizType.lecture)
            .ToList();
    }

    public Task<List<Quiz>>? GetActiveQuizzesAsync(long groupId)
    {
        
        return _context.Quizzes?
            .Where(q => q.IsActive && q.GroupId == groupId)
            .ToListAsync();
    }

    public async Task<decimal> CalculateScoreAsync(Submission submission)
    {
        var score = 0m;
        foreach (var answer in submission.Answers)
        {
            var option = await _context.Options
                .FirstOrDefaultAsync(o => o.OptionID == answer.SelectedOptionId);
            if (option != null && option.IsCorrect)
            {
                score+= answer.Question.Degree;
            }
        }
        return score;
    }

    public async Task<Submission> SubmitQuizAsync(Submission submission)
    {
        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();
        return submission;    }

    public async Task<bool> DeleteQuizAsync(long quizId)
    {
        var quiz = await _context.Quizzes.FindAsync(quizId);
        if (quiz == null)
        {
            return false;
        }

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Update(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    }

    public async Task<Quiz> GetQuizByIdAsync(long quizId)
    {
        return await _context.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(q => q.QuizId == quizId);
    }

    public async Task<Quiz> CreateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    }
}