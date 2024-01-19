using System.ComponentModel.DataAnnotations;
using CollegeSystem.DL;
using FileUploadingWebAPI.Filter;
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
    [HttpGet("GetAll")]
    public ActionResult<List<CourseReadDto>> GetAll()
    {
        return _courseManager.GetAll();
    }
    [HttpGet("getCourse/{id}")]
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
    
    
    [HttpPost("uploadImage/{id}")]
    [ImageValidator]
    public IActionResult UploadImage(IFormFile image,long id)
    {
        _courseManager.AddImageAsync(image,id);
        return Ok("Image Uploaded Successfully");
    }
    
    [HttpGet("{id}")]
    public IActionResult GetImage(int id)
    {
        _courseManager.GetImage(id);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteImage(int id)
    {
        _courseManager.DeleteImage(id);

        return Ok("Image deleted Successfully");
    }
     
    [HttpPut("{id}")]
    public IActionResult UpdateImage(int id, IFormFile file)
    {
         _courseManager.UpdateImageAsync(id, file);
        return Ok("Image Updated Successfully");
    }

    
}