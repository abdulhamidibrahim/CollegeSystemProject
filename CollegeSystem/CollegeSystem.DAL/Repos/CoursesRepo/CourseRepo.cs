
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

}