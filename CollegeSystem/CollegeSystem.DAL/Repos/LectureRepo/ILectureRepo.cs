using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface ILectureRepo :IGenericRepo<Lecture>
{
    // add lecture specific functions here
    Task<List<Lecture>> GetAllLectures(long courseId);
}