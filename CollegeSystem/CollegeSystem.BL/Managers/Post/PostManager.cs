using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PostManager:IPostManager
{
    private readonly IUnitOfWork _unitOfWork;

    public PostManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<int> Add(PostAddDto postAddDto)
    {
        var post = new Post()
        {
           Title = postAddDto.Title,
           Content = postAddDto.Content,
           Img = postAddDto.Img,
           GroupId = postAddDto.GroupId,
        };
        _unitOfWork.Post.Add(post);
        return _unitOfWork.CompleteAsync();
    }

    public Task<int> Update(PostUpdateDto postUpdateDto)
    {
        var post = _unitOfWork.Post.GetById(postUpdateDto.PostId);
        if (post == null) return Task.FromResult(0);
        
        post.Title = postUpdateDto.Title;
        post.Content = postUpdateDto.Content;
        post.Img = postUpdateDto.Img;
        post.GroupId = postUpdateDto.GroupId;
        
        _unitOfWork.Post.Update(post);
        return _unitOfWork.CompleteAsync();
    }

    public Task<int> Delete(long id)
    {
        var post = _unitOfWork.Post.GetById(id);
        if (post == null) return Task.FromResult(0);
        _unitOfWork.Post.Delete(post);
        return _unitOfWork.CompleteAsync();
    }

    public PostReadDto? Get(long id)
    {
        var post = _unitOfWork.Post.GetById(id);
        if (post == null) return null;
        return new PostReadDto()
        {
            Id = post.PostId,
            Title = post.Title,
            Content = post.Content,
            GroupId = post.GroupId,
        };
    }

    public List<PostReadDto> GetAll(long courseId)
    {
        var posts = _unitOfWork.Post.GetCourseGroupPosts(courseId);
        if (posts != null)
            return posts.Select(post => new PostReadDto()
            {
                Id = post.PostId,
                Title = post.Title,
                Content = post.Content,
                GroupId = post.GroupId,
            }).ToList();

        return null;
    }
}