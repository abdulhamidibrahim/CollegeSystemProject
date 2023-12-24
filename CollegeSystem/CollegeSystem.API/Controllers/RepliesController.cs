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
    public ActionResult<List<ReplyReadDto>> GetAll()
    {
        return _replyManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<ReplyReadDto?> Get(long id)
    {
        var user = _replyManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(ReplyAddDto replyAddDto)
    {
        _replyManager.Add(replyAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(ReplyUpdateDto replyUpdateDto)
    {
        _replyManager.Update(replyUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(ReplyDeleteDto replyDeleteDto)
    {
        _replyManager.Delete(replyDeleteDto);
        return Ok();
    }
    
}