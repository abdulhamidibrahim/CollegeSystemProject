using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermAttendanceController: ControllerBase
{
    private readonly IPermAttendanceManager _permAttendanceManager;

    public PermAttendanceController(IPermAttendanceManager permAttendanceManager)
    {
        _permAttendanceManager = permAttendanceManager;
    }
    
    [HttpGet]
    public ActionResult<List<PermAttendanceReadDto>> GetAll()
    {
        return _permAttendanceManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<PermAttendanceReadDto?> Get(long id)
    {
        var user = _permAttendanceManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(PermAttendanceAddDto permAttendanceAddDto)
    {
        _permAttendanceManager.Add(permAttendanceAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(PermAttendanceUpdateDto permAttendanceUpdateDto)
    {
        _permAttendanceManager.Update(permAttendanceUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(PermAttendanceDeleteDto permAttendanceDeleteDto)
    {
        _permAttendanceManager.Delete(permAttendanceDeleteDto);
        return Ok();
    }
    
}