using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IQuestionRepo :IGenericRepo<Question>
{
    List<Question> GetByQuizId(long quizId);
}