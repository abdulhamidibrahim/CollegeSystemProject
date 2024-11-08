using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IReplyRepo :IGenericRepo<Reply>
{
    // add reply specific functions here
    public List<Reply>? GetByPostId(long postId);
}