using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ReplyManager:IReplyManager
{
    private readonly IReplyRepo _replyRepo;
    private readonly IUnitOfWork _unitOfWork;

    public ReplyManager(IReplyRepo replyRepo, IUnitOfWork unitOfWork)
    {
        _replyRepo = replyRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(ReplyAddDto replyAddDto)
    {
        var reply = new Reply()
        {
           Content = replyAddDto.Content,
           PostId = replyAddDto.PostId,
        };
        _replyRepo.Add(reply);
        _unitOfWork.CompleteAsync();
    }

    public void Update(ReplyUpdateDto replyUpdateDto)
    {
        var reply = _replyRepo.GetById(replyUpdateDto.ReplyId);
        if (reply == null) return;
        reply.ReplyId = replyUpdateDto.ReplyId;
        reply.Content = replyUpdateDto.Content;
        reply.PostId = replyUpdateDto.PostId;

        _replyRepo.Update(reply);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(ReplyDeleteDto replyDeleteDto)
    {
        var reply = _replyRepo.GetById(replyDeleteDto.Id);
        if (reply == null) return;
        _replyRepo.Delete(reply);
        _unitOfWork.CompleteAsync();
    }

    public ReplyReadDto? Get(long id)
    {
        var reply = _replyRepo.GetById(id);
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
        var replys = _replyRepo.GetAll();
        return replys.Select(reply => new ReplyReadDto()
        {
            Id = reply.ReplyId,
            Content = reply.Content,
            PostId = reply.PostId
            
        }).ToList();
    }
    
    public List<ReplyReadDto>? GetByPostId(long id)
    {
        var replies = _replyRepo.GetByPostId(id);
        return replies?.Select(reply => new ReplyReadDto()
        {
            Content = reply.Content,
            PostId = reply.PostId
            
        }).ToList();
    }
}