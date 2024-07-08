using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class GroupManager:IGroupManager
{
    private readonly IUnitOfWork _unitOfWork;

    public GroupManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(GroupAddDto groupAddDto)
    {
        var group = new Group()
        {
           Name = groupAddDto.Name,
           Description = groupAddDto.Description,
           CourseId = groupAddDto.CourseId,
        };
        _unitOfWork.Group.Add(group);
        _unitOfWork.CompleteAsync();
    }

    public void Update(GroupUpdateDto groupUpdateDto)
    {
        var group = _unitOfWork.Group.GetById(groupUpdateDto.Id);
        if (group == null) return;
        
        group.Name = groupUpdateDto.Name;
        group.Description = groupUpdateDto.Description;
        group.CourseId = groupUpdateDto.CourseId;
        
        _unitOfWork.Group.Update(group);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var group = _unitOfWork.Group.GetById(id);
        if (group == null) return;
        _unitOfWork.Group.Delete(group);
        _unitOfWork.CompleteAsync();
    }

    public GroupReadDto? Get(long id)
    {
        var group = _unitOfWork.Group.GetById(id);
        if (group == null) return null;
        return new GroupReadDto()
        {
            Id = group.Id,
            Name = group.Name,
            Description = group.Description,
            CourseId = group.CourseId,
        };
    }

    public List<GroupReadDto> GetAll(long courseId)
    {
        var groups = _unitOfWork.Group.GetAllGroups(courseId);
        if (groups != null)
            return groups.Select(group => new GroupReadDto()
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CourseId = group.CourseId,
            }).ToList();

        throw new ArgumentException("Group not found...");
    }
}