using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepliesController: ControllerBase
{
    private readonly IReplyManager _replyManager;

    public RepliesController(IReplyManager replyManager)
    {
        _replyManager = replyManager;
    }
    [HttpGet]
    // public ActionResult<List<ReplyReadDto>> GetAll()
    // {
    //     return _replyManager.GetAll();
    // }
    // [HttpGet("{courseId}")]
    // public ActionResult<ReplyReadDto?> Get(long courseId)
    // {
    //     var reply = _replyManager.Get(courseId);
    //     if (reply == null) return NotFound(new { message = "Reply not found"});
    //     return reply;
    // }
    [HttpPost]
    public ActionResult Add(ReplyAddDto replyAddDto)
    {
        _replyManager.Add(replyAddDto);
        return Ok(new { message = "Reply added"});
    }
    [HttpPut]
    public ActionResult Update(ReplyUpdateDto replyUpdateDto)
    {
        _replyManager.Update(replyUpdateDto);
        return Ok(new { message = "Reply updated"});
    }

    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _replyManager.Delete(id);
        return Ok(new { message = "Reply deleted"});
}
    
    [HttpGet("GetByPostId/{postId}")]
    public ActionResult<List<ReplyReadDto>> GetByPostId(long postId)
    {
        return _replyManager.GetByPostId(postId)!;
    }
    
}