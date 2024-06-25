
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class CourseUserRepo :GenericRepo<CourseUser>,ICourseUserRepo
{
    private readonly CollegeSystemDbContext _context;

    public CourseUserRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

    public void AssignCourses(long[] courseId,long studentId)
    {
        foreach (var id in courseId)
        {
            _context.CourseUsers?.Add(new CourseUser()
            {
                StudentId = studentId,
                CourseId = id
            });
        }
       
    }

    public CourseUser? GetByCourseIdAndStudentId(long courseId, long studentId)
    {
            
        return _context.CourseUsers?.FirstOrDefault(x => x.CourseId == courseId && x.StudentId == studentId);
    }
    
}