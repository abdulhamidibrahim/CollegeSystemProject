using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PostManager:IPostManager
{
    private readonly IPostRepo _postRepo;
    private readonly IUnitOfWork _unitOfWork;

    public PostManager(IPostRepo postRepo, IUnitOfWork unitOfWork)
    {
        _postRepo = postRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(PostAddDto postAddDto)
    {
        var post = new Post()
        {
           Title = postAddDto.Title,
           Content = postAddDto.Content,
           Img = postAddDto.Img,
        };
        _postRepo.Add(post);
        _unitOfWork.CompleteAsync();
    }

    public void Update(PostUpdateDto postUpdateDto)
    {
        var post = _postRepo.GetById(postUpdateDto.PostId);
        if (post == null) return;
        
        post.Title = postUpdateDto.Title;
        post.Content = postUpdateDto.Content;
        post.Img = postUpdateDto.Img;
        
        _postRepo.Update(post);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(PostDeleteDto postDeleteDto)
    {
        var post = _postRepo.GetById(postDeleteDto.Id);
        if (post == null) return;
        _postRepo.Delete(post);
        _unitOfWork.CompleteAsync();
        _unitOfWork.CompleteAsync();
    }

    public PostReadDto? Get(long id)
    {
        var post = _postRepo.GetById(id);
        if (post == null) return null;
        return new PostReadDto()
        {
            Id = post.PostId,
            Title = post.Title,
            Content = post.Content,
            // Img = post.Img,
        };
    }

    public List<PostReadDto> GetAll()
    {
        var posts = _postRepo.GetAll();
        return posts.Select(post => new PostReadDto()
        {
            Id = post.PostId,
            Title = post.Title,
            Content = post.Content,
            // Img = post.Img,
            
        }).ToList();
    }
}