using System.ComponentModel.DataAnnotations;
using CollegeSystem.BL.Enums;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FileUploadingWebAPI.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

// [Authorize(Roles = nameof(Admin))]
[ApiController]
[Route("api/[controller]")]
public class CoursesController: ControllerBase
{
    private readonly ICourseManager _courseManager;

    public CoursesController(ICourseManager courseManager)
    {
        _courseManager = courseManager;
    }
    [HttpGet("GetAll")]
    public ActionResult<List<CourseReadDto>> GetAll()
    {
        return _courseManager.GetAll();
    }
    [HttpGet("getCourse/{courseId}")]
    public ActionResult<CourseReadDto?> Get(long id)
    {
        var user = _courseManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost("AddCourse")]
    public ActionResult Add(CourseAddDto courseAddDto)
    {
        _courseManager.Add(courseAddDto);
        return Ok(new {message="Group Added Successfully", status = "success"});
    }
    [HttpPut]
    public ActionResult Update(CourseUpdateDto courseUpdateDto)
    {
        _courseManager.Update(courseUpdateDto);
        return Ok(new {message="Group Updated Successfully", status = "success"});
    }
    [HttpDelete("delete/{courseId}")]
    public ActionResult Delete(long id)
    {
        _courseManager.Delete(id);
        return Ok(new {message="Group Deleted Successfully", status = "success"});
    }
    
    
    [HttpPost("uploadImage/{courseId}")]
    // [ImageValidator]
    public IActionResult UploadImage([FromForm] IFormFile image,[FromQuery] long courseId)
    {
        _courseManager.AddImageAsync(image,courseId);
        return Ok(new {message="Image Uploaded Successfully", status = "success"});
    }
    
    [HttpGet("{courseId}")]
    public IActionResult GetImage(int id)
    {
        _courseManager.GetImage(id);

        return Ok(new {message="Image Downloaded Successfully", status = "success"});
    }
    
    [HttpDelete("deleteImage/{courseId}")]
    public IActionResult DeleteImage(int id)
    {
        _courseManager.DeleteImage(id);

        return Ok(new {message="Image Deleted Successfully", status = "success"});
    }
     
    [HttpPut("{courseId}")]
    public IActionResult UpdateImage(int id, IFormFile file)
    {
         _courseManager.UpdateImageAsync(id, file);
        return Ok(new {message="Image Updated Successfully", status = "success"});
    }
    //getbylevelandterm
    [HttpGet("GetByLevelAndTerm/{studentId}/{level}/{term}")]
    public ActionResult<List<CourseReadDto>> GetByLevelAndTerm(long studentId, Level level, Term term)
    {
        return _courseManager.GetCoursesByLevelAndTerm(studentId, level, term);
    }
    // register courses

    [HttpPost("RegisterCourses")]
    public async Task<ActionResult> RegisterCourses(long[] courseIds, long studentId)
    {
         if (await _courseManager.RegisterCourses(studentId, courseIds) > 0)
              return Ok(new {message="Courses Registered Successfully", status = "success"});
         return BadRequest(new { message = "Courses Registration Failed", status = "failed" });
    }
    
}