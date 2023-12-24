
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class SectionRepo :GenericRepo<Section>,ISectionRepo
{
    private readonly CollegeSystemDbContext _context;

    public SectionRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}