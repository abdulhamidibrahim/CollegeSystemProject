using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FCISystem.DAL;

public class ReplyRepo :GenericRepo<Reply>,IReplyRepo
{
    private readonly CollegeSystemDbContext _context;

    public ReplyRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Reply>? GetByPostId(long postId)
    {
        return _context.Replies?
            .Include(x=>x.Student)
            .Include(x=>x.Staff)
            .Where(reply => reply.PostId == postId)
            .ToList();
    }
}