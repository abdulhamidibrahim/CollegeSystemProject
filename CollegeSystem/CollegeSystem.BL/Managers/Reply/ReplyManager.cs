using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ReplyManager:IReplyManager
{
    private readonly IReplyRepo _replyRepo;

    public ReplyManager(IReplyRepo replyRepo)
    {
        _replyRepo = replyRepo;
    }
    
    public void Add(ReplyAddDto replyAddDto)
    {
        var reply = new Reply()
        {
           Content = replyAddDto.Content,
           PostId = replyAddDto.PostId,
        };
        _replyRepo.Add(reply);
    }

    public void Update(ReplyUpdateDto replyUpdateDto)
    {
        var reply = _replyRepo.GetById(replyUpdateDto.ReplyId);
        if (reply == null) return;
        reply.ReplyId = replyUpdateDto.ReplyId;
        reply.Content = replyUpdateDto.Content;
        reply.PostId = replyUpdateDto.PostId;

        _replyRepo.Update(reply);
    }

    public void Delete(ReplyDeleteDto replyDeleteDto)
    {
        var reply = _replyRepo.GetById(replyDeleteDto.Id);
        if (reply == null) return;
        _replyRepo.Delete(reply);
    }

    public ReplyReadDto? Get(long id)
    {
        var reply = _replyRepo.GetById(id);
        if (reply == null) return null;
        return new ReplyReadDto()
        {
            Content = reply.Content,
            PostId = reply.PostId
        };
    }

    public List<ReplyReadDto> GetAll()
    {
        var replys = _replyRepo.GetAll();
        return replys.Select(reply => new ReplyReadDto()
        {
            Content = reply.Content,
            PostId = reply.PostId
            
        }).ToList();
    }
}