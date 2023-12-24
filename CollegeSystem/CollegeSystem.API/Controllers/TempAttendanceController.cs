using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TempAttendanceController: ControllerBase
{
    private readonly ITempAttendanceManager _permAttendanceManager;

    public TempAttendanceController(ITempAttendanceManager permAttendanceManager)
    {
        _permAttendanceManager = permAttendanceManager;
    }
    
    [HttpGet]
    public ActionResult<List<TempAttendanceReadDto>> GetAll()
    {
        return _permAttendanceManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<TempAttendanceReadDto?> Get(long id)
    {
        var user = _permAttendanceManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(TempAttendanceAddDto permAttendanceAddDto)
    {
        _permAttendanceManager.Add(permAttendanceAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(TempAttendanceUpdateDto permAttendanceUpdateDto)
    {
        _permAttendanceManager.Update(permAttendanceUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(TempAttendanceDeleteDto permAttendanceDeleteDto)
    {
        _permAttendanceManager.Delete(permAttendanceDeleteDto);
        return Ok();
    }
    
}