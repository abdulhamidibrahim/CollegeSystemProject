using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PostManager:IPostManager
{
    private readonly IPostRepo _postRepo;

    public PostManager(IPostRepo postRepo)
    {
        _postRepo = postRepo;
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
    }

    public void Update(PostUpdateDto postUpdateDto)
    {
        var post = _postRepo.GetById(postUpdateDto.PostId);
        if (post == null) return;
        
        post.Title = postUpdateDto.Title;
        post.Content = postUpdateDto.Content;
        post.Img = postUpdateDto.Img;
        
        _postRepo.Update(post);
    }

    public void Delete(PostDeleteDto postDeleteDto)
    {
        var post = _postRepo.GetById(postDeleteDto.Id);
        if (post == null) return;
        _postRepo.Delete(post);
    }

    public PostReadDto? Get(long id)
    {
        var post = _postRepo.GetById(id);
        if (post == null) return null;
        return new PostReadDto()
        {
            Title = post.Title,
            Content = post.Content,
            Img = post.Img,
        };
    }

    public List<PostReadDto> GetAll()
    {
        var posts = _postRepo.GetAll();
        return posts.Select(post => new PostReadDto()
        {
            Title = post.Title,
            Content = post.Content,
            Img = post.Img,
            
        }).ToList();
    }
}