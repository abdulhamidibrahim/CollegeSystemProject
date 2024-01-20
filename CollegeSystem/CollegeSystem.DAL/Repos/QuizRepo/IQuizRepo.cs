using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IQuizRepo :IGenericRepo<Quiz>
{
    // add quiz specific functions here
    Quiz? GetByLectureId(long lectureId);
    Quiz? GetBySectionId(long sectionId);
    List<Quiz>? GetAll(long courseId);
    List<Quiz>? GetAllSectionQuizzes(long courseId);
    List<Quiz>? GetAllLectureQuizzes(long courseId);
    
}