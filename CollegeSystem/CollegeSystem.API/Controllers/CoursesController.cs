using System.ComponentModel.DataAnnotations;
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
        return Ok(new {message="Course Added Successfully", status = "success"});
    }
    [HttpPut]
    public ActionResult Update(CourseUpdateDto courseUpdateDto)
    {
        _courseManager.Update(courseUpdateDto);
        return Ok(new {message="Course Updated Successfully", status = "success"});
    }
    [HttpDelete]
    public ActionResult Delete(CourseDeleteDto courseDeleteDto)
    {
        _courseManager.Delete(courseDeleteDto);
        return Ok(new {message="Course Deleted Successfully", status = "success"});
    }
    
    
    [HttpPost("uploadImage/{id}")]
    [ImageValidator]
    public IActionResult UploadImage(IFormFile image,long id)
    {
        _courseManager.AddImageAsync(image,id);
        return Ok(new {message="Image Uploaded Successfully", status = "success"});
    }
    
    [HttpGet("{id}")]
    public IActionResult GetImage(int id)
    {
        _courseManager.GetImage(id);

        return Ok(new {message="Image Downloaded Successfully", status = "success"});
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteImage(int id)
    {
        _courseManager.DeleteImage(id);

        return Ok(new {message="Image Deleted Successfully", status = "success"});
    }
     
    [HttpPut("{id}")]
    public IActionResult UpdateImage(int id, IFormFile file)
    {
         _courseManager.UpdateImageAsync(id, file);
        return Ok(new {message="Image Updated Successfully", status = "success"});
    }
    //getbylevelandterm
    [HttpGet("GetByLevelAndTerm/{level}/{term}")]
    public ActionResult<List<CourseReadDto>> GetByLevelAndTerm(string level, string term)
    {
        return _courseManager.GetCoursesByLevelAndTerm(level, term);
    }
    
}