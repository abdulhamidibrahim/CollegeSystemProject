using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController: ControllerBase
{
    private readonly ICourseManager _courseManager;

    public CoursesController(ICourseManager courseManager)
    {
        _courseManager = courseManager;
    }
    [HttpGet]
    public ActionResult<List<CourseReadDto>> GetAll()
    {
        return _courseManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<CourseReadDto?> Get(long id)
    {
        var user = _courseManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(CourseAddDto courseAddDto)
    {
        _courseManager.Add(courseAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(CourseUpdateDto courseUpdateDto)
    {
        _courseManager.Update(courseUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(CourseDeleteDto courseDeleteDto)
    {
        _courseManager.Delete(courseDeleteDto);
        return Ok();
    }
    
}