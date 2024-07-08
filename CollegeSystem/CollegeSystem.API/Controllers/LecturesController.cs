using System.ComponentModel.DataAnnotations;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

// [Authorize(Roles = "Teacher")]
[ApiController]
[Route("api/[controller]")]
public class LecturesController: ControllerBase
{
    private readonly ILectureManager _lectureManager;

    public LecturesController(ILectureManager lectureManager)
    {
        _lectureManager = lectureManager;
    }
    
    [HttpGet("getAll/{groupId}")]
    public ActionResult<List<LectureReadDto>> GetAll([Required] long groupId)
    {
        return _lectureManager.GetAll(groupId);
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<LectureReadDto?> Get(long id)
    {
        var user = _lectureManager.Get(id);
        if (user == null) return NotFound(new {message = "Lecture Not Found", status = "error"});
        return Ok(user);
    }
    
    [HttpPost]
    public ActionResult Add(LectureAddDto lectureAddDto)
    {
        _lectureManager.Add(lectureAddDto);
        return Ok(new {message = "Lecture Added Successfully", status = "success"});
    }
    
    [HttpPut]
    public ActionResult Update(LectureUpdateDto lectureUpdateDto)
    {
        _lectureManager.Update(lectureUpdateDto);
        return Ok(new {message = "Lecture Updated Successfully", status = "success"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _lectureManager.Delete(id);
        return Ok(new {message = "Lecture Deleted Successfully", status = "success"});
    }
    
    [HttpPost("uploadFile/{courseId}")]
    public IActionResult UploadFile(IFormFile file,long id)
    {
        _lectureManager.AddFileAsync(file,id);
        return Ok(new {message ="File Uploaded Successfully", status = "success"});
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getAllFiles")]
    public ActionResult<List<UploadLectureFileDto>> GetAllFiles()
    {
        return _lectureManager.GetAllFiles()!;
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getFile/{courseId}")]
    public IActionResult GetFile(int id)
    {
        var file = _lectureManager.GetFile(id);
        if (file == null) return NotFound(new {message = "File Not Found", status = "error"});
        return File(file.Content,file.Extension);
    }
    
    [HttpDelete("deleteFile/{courseId}")]
    public IActionResult DeleteFile(int id)
    {
        _lectureManager.DeleteFile(id);
        return Ok(new {message = "File Deleted Successfully", status = "success"});
    }
    
    [HttpPut("updateFile/{courseId}")]
    public IActionResult UpdateFile(int id, IFormFile file)
    {
        _lectureManager.UpdateFileAsync(id,file);
        return Ok(new {message = "File Updated Successfully", status = "success"});
    }
}