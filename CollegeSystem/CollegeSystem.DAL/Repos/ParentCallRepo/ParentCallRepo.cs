using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class ParentCallRepo :GenericRepo<ParentCall>,IParentCallRepo
{
    private readonly CollegeSystemDbContext _context;

    public ParentCallRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}