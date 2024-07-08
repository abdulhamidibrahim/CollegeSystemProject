using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PostUsersManager:IPostUsersManager
{
    private readonly IUnitOfWork _unitOfWork;

    public PostUsersManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(PostUsersAddDto postUsersAddDto)
    {
        var postUsers = new PostUser()
        {
            StudentId = postUsersAddDto.StudentId,
            StaffId = postUsersAddDto.StaffId,
            PostId = postUsersAddDto.PostId,
        };
        _unitOfWork.PostUser.Add(postUsers);
        _unitOfWork.CompleteAsync();
    }

    public void Update(PostUsersUpdateDto postUsersUpdateDto)
    {
        var postUsers = _unitOfWork.PostUser.GetById(postUsersUpdateDto.PostUserId);
        if (postUsers == null) return;
        
        postUsers.PostId = postUsersUpdateDto.PostId;
        postUsers.StudentId = postUsersUpdateDto.StudentId;
        postUsers.StaffId = postUsersUpdateDto.StaffId;

        _unitOfWork.PostUser.Update(postUsers);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(PostUsersDeleteDto postUsersDeleteDto)
    {
        var postUsers = _unitOfWork.PostUser.GetById(postUsersDeleteDto.Id);
        if (postUsers == null) return;
        _unitOfWork.PostUser.Delete(postUsers);
        _unitOfWork.CompleteAsync();
    }

    public PostUsersReadDto? Get(long id)
    {
        var postUsers = _unitOfWork.PostUser.GetById(id);
        if (postUsers == null) return null;
        return new PostUsersReadDto()
        {
            StaffId = postUsers.StaffId,
            StudentId = postUsers.StudentId,
            PostId = postUsers.PostId,
        };
    }

    public List<PostUsersReadDto> GetAll()
    {
        var postUserss = _unitOfWork.PostUser.GetAll();
        return postUserss.Select(postUsers => new PostUsersReadDto()
        {
            StaffId = postUsers.StaffId,
            PostId = postUsers.PostId,
            StudentId = postUsers.StudentId
        }).ToList();
    }
}