using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class PostRepo :GenericRepo<Post>,IPostRepo
{
    private readonly CollegeSystemDbContext _context;

    public PostRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

}