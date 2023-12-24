
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

}