using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseUserController : ControllerBase
{
    private readonly ICourseUserManager _courseUserManager;

    public CourseUserController(ICourseUserManager courseUserManager)
    {
        _courseUserManager = courseUserManager;
    }
    [HttpGet]
    public ActionResult<List<CourseUserReadDto>> GetAll()
    {
        return _courseUserManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<CourseUserReadDto?> Get(long id)
    {
        var user = _courseUserManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(CourseUserAddDto courseUserAddDto)
    {
        _courseUserManager.Add(courseUserAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(CourseUserUpdateDto courseUserUpdateDto)
    {
        _courseUserManager.Update(courseUserUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(CourseUserDeleteDto courseUserDeleteDto)
    {
        _courseUserManager.Delete(courseUserDeleteDto);
        return Ok();
    }

}