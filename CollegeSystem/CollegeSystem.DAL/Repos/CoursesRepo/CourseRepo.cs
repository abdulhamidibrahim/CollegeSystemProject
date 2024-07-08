
using System.Collections;
using CollegeSystem.BL.Enums;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

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

    public List<CourseUser> GetCoursesByLevelAndTerm(long studentId, Level level, Term term)
    {
        if (_context.Courses == null || _context.CourseUsers == null)
        {
            return new List<CourseUser>();
        }
    
        return _context.CourseUsers
            .Include(x=>x.Course)
            .Where(c => c.StudentId == studentId && c.Course.Level == level && c.Course.Term == term)
            .AsQueryable()
            .ToList();
    }

    public IEnumerable<Course> GetCoursesByIds(long[] courseId)
    {
        if (_context.Courses != null) return _context.Courses
            .Where(c => courseId.Contains(c.CourseId))
            .AsQueryable()
            .ToList();
        return new List<Course>();
    }
}