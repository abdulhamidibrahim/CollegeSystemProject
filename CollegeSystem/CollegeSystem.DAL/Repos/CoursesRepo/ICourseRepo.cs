using System.Collections;
using CollegeSystem.BL.Enums;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface ICourseRepo :IGenericRepo<Course>
{
    // add course specific functions here
    List<Course> GetCoursesByDeptId(int deptId);
    List<CourseUser> GetCoursesByLevelAndTerm(long studentId, Level level, Term term);
    IEnumerable<Course> GetCoursesByIds(long[] courseId);
}