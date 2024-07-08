using CollegeSystem.BL.DTOs.Submission;
using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public interface IQuizManager
{
    List<QuizReadDto> GetAllSectionQuizzes(long groupId); 
    List<QuizReadDto> GetAllLectureQuizzes(long courseId);
    Task<Quiz> CreateQuizAsync(QuizAddDto quiz);
    Task<Quiz> GetQuizByIdAsync(long quizId);
    Task<List<Quiz>> GetActiveQuizzesAsync(long courseId);
    Task<Quiz> UpdateQuizAsync(QuizUpdateDto quiz);
    Task<bool> DeleteQuizAsync(long quizId);
    Task<Submission> SubmitQuizAsync(SubmissionDto submission);
    // Task<int> CalculateScoreAsync(SubmissionDto submission);
}