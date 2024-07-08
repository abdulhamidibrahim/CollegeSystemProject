using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbacksController: ControllerBase
{
    private readonly IFeedbackManager _feedbackManager;

    public FeedbacksController(IFeedbackManager feedbackManager)
    {
        _feedbackManager = feedbackManager;
    }
    
    [HttpGet]
    public ActionResult<List<FeedbackReadDto>> GetAll()
    {
        return _feedbackManager.GetAll();
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<FeedbackReadDto?> Get(long id)
    {
        var feedback = _feedbackManager.Get(id);
        if (feedback == null) return NotFound(new { message = "Feedback not found"});
        return feedback;
    }
    
    [HttpPost]
    public ActionResult Add(FeedbackAddDto feedbackAddDto)
    {
        _feedbackManager.Add(feedbackAddDto);
        return Ok(new { message = "Feedback added"});
    }
    
    [HttpPut]
    public ActionResult Update(FeedbackUpdateDto feedbackUpdateDto)
    {
        _feedbackManager.Update(feedbackUpdateDto);
        return Ok(new { message = "Feedback updated"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _feedbackManager.Delete(id);
        return Ok(new { message = "Feedback deleted"});
    }
    
}