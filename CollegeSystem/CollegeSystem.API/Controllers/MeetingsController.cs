using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetingsController: ControllerBase
{
    private readonly IMeetingManager _meetingManager;

    public MeetingsController(IMeetingManager meetingManager)
    {
        _meetingManager = meetingManager;
    }
    [HttpGet]
    public ActionResult<List<MeetingReadDto>> GetAll()
    {
        return _meetingManager.GetAll();
    }
    [HttpGet("{courseId}")]
    public ActionResult<MeetingReadDto?> Get(long id)
    {
        var meeting = _meetingManager.Get(id);
        if (meeting == null) return NotFound(new {message="Meeting not found"});
        return meeting;
    }
    [HttpPost]
    public ActionResult Add(MeetingAddDto meetingAddDto)
    {
        _meetingManager.Add(meetingAddDto);
        return Ok(new {message="Meeting added successfully"});
    }
    [HttpPut]
    public ActionResult Update(MeetingUpdateDto meetingUpdateDto)
    {
        _meetingManager.Update(meetingUpdateDto);
        return Ok(new {message="Meeting updated successfully"});
    }
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _meetingManager.Delete(id);
        return Ok(new {message="Meeting deleted successfully"});
    }
    
    [HttpGet("GetAllByGroupId/{groupId}")]
    public ActionResult<List<MeetingReadDto>> GetAllByGroupId(long groupId)
    {
        return _meetingManager.GetAllByGroupId(groupId);
    }
    
}