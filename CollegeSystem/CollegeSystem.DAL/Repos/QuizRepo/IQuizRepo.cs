using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IQuizRepo :IGenericRepo<Quiz>
{
    // add quiz specific functions here
    // Quiz? GetByLectureId(long lectureId);
    // Quiz? GetBySectionId(long sectionId);
    // List<Quiz>? GetAll(long groupId);
    List<Quiz>? GetAllSectionQuizzes(long groupId);
    List<Quiz>? GetAllLectureQuizzes(long groupId); 
    Task<List<Quiz>>? GetActiveQuizzesAsync(long groupId);
    Task<decimal> CalculateScoreAsync(Submission submission);
    Task<Submission> SubmitQuizAsync(Submission submission);
    Task<bool> DeleteQuizAsync(long quizId);
    Task<Quiz> UpdateQuizAsync(Quiz quiz);
    Task<Quiz> GetQuizByIdAsync(long quizId);
    Task<Quiz> CreateQuizAsync(Quiz quiz);





}