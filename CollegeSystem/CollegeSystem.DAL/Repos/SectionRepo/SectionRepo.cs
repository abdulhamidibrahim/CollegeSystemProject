
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FCISystem.DAL;

public class SectionRepo :GenericRepo<Section>,ISectionRepo
{
    private readonly CollegeSystemDbContext _context;

    public SectionRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<Section>> GetAllSections(long groupId)
    {
        return _context.Sections!.Where(x => x.GroupId == groupId).ToListAsync();
    }
}