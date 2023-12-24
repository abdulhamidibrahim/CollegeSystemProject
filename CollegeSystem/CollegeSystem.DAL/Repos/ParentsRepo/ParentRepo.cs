
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class ParentRepo :GenericRepo<Parent>,IParentRepo
{
    private readonly CollegeSystemDbContext _context;

    public ParentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}