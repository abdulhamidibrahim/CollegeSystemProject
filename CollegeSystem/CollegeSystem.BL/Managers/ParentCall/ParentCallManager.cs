using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentCallManager :IParentCallManager
{
    private readonly IParentCallRepo _parentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public ParentCallManager(IParentCallRepo parentRepo, IUnitOfWork unitOfWork)
    {
        _parentRepo = parentRepo;
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
        _parentRepo.Add(parent);
        _unitOfWork.CompleteAsync();
    }

    public void Update(ParentCallUpdateDto parentUpdateDto)
    {
        var parent = _parentRepo.GetById(parentUpdateDto.MessageId);
        if (parent == null) return;
        parent.MessageId = parentUpdateDto.MessageId;
        parent.Message = parentUpdateDto.Message;
        parent.File = parentUpdateDto.File;
        parent.ParentEmail = parentUpdateDto.ParentEmail;
        
        _parentRepo.Update(parent);
    }

    public void Delete(ParentCallDeleteDto parentDeleteDto)
    {
        var parent = _parentRepo.GetById(parentDeleteDto.Id);
        if (parent == null) return;
        _parentRepo.Delete(parent);
    }

    public ParentCallReadDto? Get(long id)
    {
        var parent = _parentRepo.GetById(id);
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
        var parents = _parentRepo.GetAll();
        return parents.Select(parent => new ParentCallReadDto()
        {
            Id = parent.MessageId,
            Message = parent.Message,
            File = parent.File,
            ParentEmail = parent.ParentEmail   
            
        }).ToList();
    }
}