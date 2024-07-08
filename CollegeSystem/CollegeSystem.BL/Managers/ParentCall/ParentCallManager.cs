using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentCallManager :IParentCallManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ParentCallManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(ParentCallAddDto parentAddDto)
    {
        var parent = new ParentCall()
        {
           File = parentAddDto.File,
           Message = parentAddDto.Message,
           ParentEmail = parentAddDto.ParentEmail
        };
        _unitOfWork.ParentCall.Add(parent);
        _unitOfWork.CompleteAsync();
    }

    public void Update(ParentCallUpdateDto parentUpdateDto)
    {
        var parent = _unitOfWork.ParentCall.GetById(parentUpdateDto.MessageId);
        if (parent == null) return;
        parent.MessageId = parentUpdateDto.MessageId;
        parent.Message = parentUpdateDto.Message;
        parent.File = parentUpdateDto.File;
        parent.ParentEmail = parentUpdateDto.ParentEmail;
        
        _unitOfWork.ParentCall.Update(parent);
    }

    public void Delete(long id)
    {
        var parent = _unitOfWork.ParentCall.GetById(id);
        if (parent == null) return;
        _unitOfWork.ParentCall.Delete(parent);
    }

    public ParentCallReadDto? Get(long id)
    {
        var parent = _unitOfWork.ParentCall.GetById(id);
        if (parent == null) return null;
        return new ParentCallReadDto()
        {
            Id = parent.MessageId,
            Message = parent.Message,
            File = parent.File,
            ParentEmail = parent.ParentEmail            
        };
    }

    public List<ParentCallReadDto> GetAll()
    {
        var parents = _unitOfWork.ParentCall.GetAll();
        return parents.Select(parent => new ParentCallReadDto()
        {
            Id = parent.MessageId,
            Message = parent.Message,
            File = parent.File,
            ParentEmail = parent.ParentEmail   
            
        }).ToList();
    }
}