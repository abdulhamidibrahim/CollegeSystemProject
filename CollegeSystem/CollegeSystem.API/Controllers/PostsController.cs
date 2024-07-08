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
    
    [HttpGet("{groupId}")]
    public ActionResult<List<PostReadDto>> GetAll(long groupId)
    {
        
            var result =_postManager.GetAll(groupId);   
            if (result == null) return NotFound(new { message = "Group not found, or there is no posts in this group"});
            return Ok(result);
            
    }
    
    [HttpGet("/{courseId}")]
    public ActionResult<PostReadDto?> Get(long id)
    {
        var post = _postManager.Get(id);
        if (post == null) return NotFound(new { message = "post not found"});
        return post;
    }
    
    [HttpPost]
    public ActionResult Add(PostAddDto postAddDto)
    {
        var result = _postManager.Add(postAddDto);
        if (result == Task.FromResult(0)) return BadRequest(new { message = "Failed to add post"});
        return Ok(new { message = "post added"});
    }
    
    [HttpPut]
    public ActionResult Update(PostUpdateDto postUpdateDto)
    {
        _postManager.Update(postUpdateDto);
        return Ok(new { message = "post updated"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _postManager.Delete(id);
        return Ok(new { message = "post deleted"});
    }
    
}