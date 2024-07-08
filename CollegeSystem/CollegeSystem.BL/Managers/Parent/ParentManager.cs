using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ParentManager:IParentManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ParentManager(IUnitOfWork unitOfWork)
    {
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
        _unitOfWork.Parent.Add(parent);
        _unitOfWork.CompleteAsync();
    }

    public void Update(ParentUpdateDto parentUpdateDto)
    {
        var parent = _unitOfWork.Parent.GetById(parentUpdateDto.ParentId);
        if (parent == null) return;
        parent.Name = parentUpdateDto.Name;
        parent.Email = parentUpdateDto.Email;
        parent.Phone = parentUpdateDto.Phone;
        
        _unitOfWork.Parent.Update(parent);
        _unitOfWork.CompleteAsync();
        
    }

    public void Delete(long id)
    {
        var parent = _unitOfWork.Parent.GetById(id);
        if (parent == null) return;
        _unitOfWork.Parent.Delete(parent);
        _unitOfWork.CompleteAsync();
        
    }

    public ParentReadDto? Get(long id)
    {
        var parent = _unitOfWork.Parent.GetById(id);
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
        var parents = _unitOfWork.Parent.GetAll();
        return parents.Select(parent => new ParentReadDto()
        {
            Id = parent.Id,
            Name = parent.Name,
            Email = parent.Email,
            Phone = parent.Phone,
            
        }).ToList();
    }
}