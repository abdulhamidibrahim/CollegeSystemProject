
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FCISystem.DAL;

public class LectureRepo :GenericRepo<Lecture>,ILectureRepo
{
    private readonly CollegeSystemDbContext _context;

    public LectureRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Lecture>> GetAllLectures(long groupId)
    {
        return await _context.Lectures!.Where(x => x.GroupId == groupId).ToListAsync();
    }
    
}