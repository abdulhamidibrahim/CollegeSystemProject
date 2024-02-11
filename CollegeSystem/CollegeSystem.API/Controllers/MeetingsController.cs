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
    [HttpGet("{id}")]
    public ActionResult<MeetingReadDto?> Get(long id)
    {
        var user = _meetingManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(MeetingAddDto meetingAddDto)
    {
        _meetingManager.Add(meetingAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(MeetingUpdateDto meetingUpdateDto)
    {
        _meetingManager.Update(meetingUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(MeetingDeleteDto meetingDeleteDto)
    {
        _meetingManager.Delete(meetingDeleteDto);
        return Ok();
    }
    
    
}