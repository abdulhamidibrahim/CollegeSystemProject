using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class GroupRepo :GenericRepo<Group>,IGroupRepo
{
    private readonly CollegeSystemDbContext _context;

    public GroupRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Group> GetAllGroups(long courseId)
    {
        return _context.Groups!.Where(g => g.CourseId == courseId);
    }
}