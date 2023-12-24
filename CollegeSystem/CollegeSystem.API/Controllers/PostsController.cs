using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController: ControllerBase
{
    private readonly IPostManager _postManager;

    public PostsController(IPostManager postManager)
    {
        _postManager = postManager;
    }
    
    [HttpGet]
    public ActionResult<List<PostReadDto>> GetAll()
    {
        return _postManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<PostReadDto?> Get(long id)
    {
        var user = _postManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(PostAddDto postAddDto)
    {
        _postManager.Add(postAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(PostUpdateDto postUpdateDto)
    {
        _postManager.Update(postUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(PostDeleteDto postDeleteDto)
    {
        _postManager.Delete(postDeleteDto);
        return Ok();
    }
    
}