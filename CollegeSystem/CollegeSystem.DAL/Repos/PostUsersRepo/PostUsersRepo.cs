using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class PostUsersRepo :GenericRepo<PostUser>,IPostUsersRepo
{
    private readonly CollegeSystemDbContext _context;

    public PostUsersRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}