
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IActiveQuizRepo :IGenericRepo<ActiveQuiz>
{

    ActiveQuiz? GetByQuizId(long quizId);
}