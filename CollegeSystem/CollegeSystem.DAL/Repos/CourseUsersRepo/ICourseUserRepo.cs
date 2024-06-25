using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface ICourseUserRepo :IGenericRepo<CourseUser>
{
    // add course users specific functions here
    // add courses for user 
    void AssignCourses(long[] courseId,long studentId);
    CourseUser? GetByCourseIdAndStudentId(long courseId, long studentId);
}