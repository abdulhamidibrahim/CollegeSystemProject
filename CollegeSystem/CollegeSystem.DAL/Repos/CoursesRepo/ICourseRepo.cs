using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface ICourseRepo :IGenericRepo<Course>
{
    // add course specific functions here
    List<Course> GetCoursesByDeptId(int deptId);
    List<Course> GetCoursesByLevelAndTerm(string level, string term);
}