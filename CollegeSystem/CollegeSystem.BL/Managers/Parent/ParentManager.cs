using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentManager:IParentManager
{
    private readonly IParentRepo _parentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public ParentManager(IParentRepo parentRepo, IUnitOfWork unitOfWork)
    {
        _parentRepo = parentRepo;
        _unitOfWork = unitOfWork;
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
        _unitOfWork.CompleteAsync();
    }

    public void Update(ParentUpdateDto parentUpdateDto)
    {
        var parent = _parentRepo.GetById(parentUpdateDto.ParentId);
        if (parent == null) return;
        parent.Name = parentUpdateDto.Name;
        parent.Email = parentUpdateDto.Email;
        parent.Phone = parentUpdateDto.Phone;
        
        _parentRepo.Update(parent);
        _unitOfWork.CompleteAsync();
        
    }

    public void Delete(ParentDeleteDto parentDeleteDto)
    {
        var parent = _parentRepo.GetById(parentDeleteDto.Id);
        if (parent == null) return;
        _parentRepo.Delete(parent);
        _unitOfWork.CompleteAsync();
        
    }

    public ParentReadDto? Get(long id)
    {
        var parent = _parentRepo.GetById(id);
        if (parent == null) return null;
        return new ParentReadDto()
        {
            Id = parent.Id,
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
            Id = parent.Id,
            Name = parent.Name,
            Email = parent.Email,
            Phone = parent.Phone,
            
        }).ToList();
    }
}