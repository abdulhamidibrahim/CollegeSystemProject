
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class CourseRepo :GenericRepo<Course>,ICourseRepo
{
    private readonly CollegeSystemDbContext _context;

    public CourseRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Course> GetCoursesByDeptId(int deptId)
    {
        if (_context.Courses != null) return _context.Courses
            .Where(c => c.DeptId == deptId)
            .AsQueryable()
            .ToList();
        return new List<Course>();
    }

    public List<Course> GetCoursesByLevelAndTerm(string level, string term)
    {
        if (_context.Courses != null) return _context.Courses
            .Where(c => c.Level == level && c.Term == term)
            .AsQueryable()
            .ToList();
        return new List<Course>();
    }
}