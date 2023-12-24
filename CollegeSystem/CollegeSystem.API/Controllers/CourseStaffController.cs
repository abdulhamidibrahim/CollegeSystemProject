using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseStaffController : ControllerBase
{
    private readonly ICourseStaffManager _courseStaffManager;

    public CourseStaffController(ICourseStaffManager courseStaffManager)
    {
        _courseStaffManager = courseStaffManager;
    }
    
    [HttpGet]
    public ActionResult<List<CourseStaffReadDto>> GetAll()
    {
        return _courseStaffManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<CourseStaffReadDto?> Get(long id)
    {
        var user = _courseStaffManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(CourseStaffAddDto courseStaffAddDto)
    {
        _courseStaffManager.Add(courseStaffAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(CourseStaffUpdateDto courseStaffUpdateDto)
    {
        _courseStaffManager.Update(courseStaffUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(CourseStaffDeleteDto courseStaffDeleteDto)
    {
        _courseStaffManager.Delete(courseStaffDeleteDto);
        return Ok();
    }

}