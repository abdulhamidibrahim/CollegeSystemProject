using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentCallManager :IParentCallManager
{
    private readonly IParentCallRepo _parentRepo;

    public ParentCallManager(IParentCallRepo parentRepo)
    {
        _parentRepo = parentRepo;
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
            Message = parent.Message,
            File = parent.File,
            ParentEmail = parent.ParentEmail   
            
        }).ToList();
    }
}