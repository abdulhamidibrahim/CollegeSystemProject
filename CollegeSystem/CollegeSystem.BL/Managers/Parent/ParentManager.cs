using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentManager:IParentManager
{
    private readonly IParentRepo _parentRepo;

    public ParentManager(IParentRepo parentRepo)
    {
        _parentRepo = parentRepo;
    }
    
    public void Add(ParentAddDto parentAddDto)
    {
        var parent = new Parent()
        {
            Name = parentAddDto.Name,
            Email = parentAddDto.Email,
            Phone = parentAddDto.Phone,
        };
        _parentRepo.Add(parent);
    }

    public void Update(ParentUpdateDto parentUpdateDto)
    {
        var parent = _parentRepo.GetById(parentUpdateDto.ParentId);
        if (parent == null) return;
        parent.Name = parentUpdateDto.Name;
        parent.Email = parentUpdateDto.Email;
        parent.Phone = parentUpdateDto.Phone;
        
        _parentRepo.Update(parent);
    }

    public void Delete(ParentDeleteDto parentDeleteDto)
    {
        var parent = _parentRepo.GetById(parentDeleteDto.Id);
        if (parent == null) return;
        _parentRepo.Delete(parent);
    }

    public ParentReadDto? Get(long id)
    {
        var parent = _parentRepo.GetById(id);
        if (parent == null) return null;
        return new ParentReadDto()
        {
            Name = parent.Name,
            Email = parent.Email,
            Phone = parent.Phone,
        };
    }

    public List<ParentReadDto> GetAll()
    {
        var parents = _parentRepo.GetAll();
        return parents.Select(parent => new ParentReadDto()
        {
            Name = parent.Name,
            Email = parent.Email,
            Phone = parent.Phone,
            
        }).ToList();
    }
}