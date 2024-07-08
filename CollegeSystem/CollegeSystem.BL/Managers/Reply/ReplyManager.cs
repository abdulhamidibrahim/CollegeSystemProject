using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ReplyManager:IReplyManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ReplyManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(ReplyAddDto replyAddDto)
    {
        var reply = new Reply()
        {
           Content = replyAddDto.Content,
           PostId = replyAddDto.PostId,
        };
        _unitOfWork.Reply.Add(reply);
        _unitOfWork.CompleteAsync();
    }

    public void Update(ReplyUpdateDto replyUpdateDto)
    {
        var reply = _unitOfWork.Reply.GetById(replyUpdateDto.ReplyId);
        if (reply == null) return;
        reply.ReplyId = replyUpdateDto.ReplyId;
        reply.Content = replyUpdateDto.Content;
        reply.PostId = replyUpdateDto.PostId;

        _unitOfWork.Reply.Update(reply);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var reply = _unitOfWork.Reply.GetById(id);
        if (reply == null) return;
        _unitOfWork.Reply.Delete(reply);
        _unitOfWork.CompleteAsync();
    }

    public ReplyReadDto? Get(long id)
    {
        var reply = _unitOfWork.Reply.GetById(id);
        if (reply == null) return null;
        return new ReplyReadDto()
        {
            Id = reply.ReplyId,
            Content = reply.Content,
            PostId = reply.PostId
        };
    }

    public List<ReplyReadDto> GetAll()
    {
        var replys = _unitOfWork.Reply.GetAll();
        return replys.Select(reply => new ReplyReadDto()
        {
            Id = reply.ReplyId,
            Content = reply.Content,
            PostId = reply.PostId
            
        }).ToList();
    }
    
    public List<ReplyReadDto>? GetByPostId(long id)
    {
        var replies = _unitOfWork.Reply.GetByPostId(id);
        return replies?.Select(reply => new ReplyReadDto()
        {
            Content = reply.Content,
            PostId = reply.PostId,
            User = reply.Student != null ? reply.Student.UserName ?? reply.Staff?.UserName : "unknown"
            
        }).ToList();
    }
}