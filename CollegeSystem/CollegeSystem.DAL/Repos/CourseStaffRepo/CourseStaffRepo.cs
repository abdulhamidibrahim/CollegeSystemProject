
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class CourseStaffRepo :GenericRepo<CourseStaff>,ICourseStaffRepo
{
    private readonly CollegeSystemDbContext _context;

    public CourseStaffRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

}