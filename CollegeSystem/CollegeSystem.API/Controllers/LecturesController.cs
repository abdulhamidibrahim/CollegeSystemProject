using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[Authorize(Roles = "Teacher")]
[ApiController]
[Route("api/[controller]")]
public class LecturesController: ControllerBase
{
    private readonly ILectureManager _lectureManager;

    public LecturesController(ILectureManager lectureManager)
    {
        _lectureManager = lectureManager;
    }
    
    [HttpGet]
    public ActionResult<List<LectureReadDto>> GetAll(long courseId)
    {
        return _lectureManager.GetAll(courseId);
    }
    
    [HttpGet("{id}")]
    public ActionResult<LectureReadDto?> Get(long id)
    {
        var user = _lectureManager.Get(id);
        if (user == null) return NotFound();
        return Ok(user.Files.Select(f=>new {f.Id,f.Name , f.Extension}).ToList());
    }
    
    [HttpPost]
    public ActionResult Add(LectureAddDto lectureAddDto)
    {
        _lectureManager.Add(lectureAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(LectureUpdateDto lectureUpdateDto)
    {
        _lectureManager.Update(lectureUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(LectureDeleteDto lectureDeleteDto)
    {
        _lectureManager.Delete(lectureDeleteDto);
        return Ok();
    }
    
    [HttpPost("uploadFile/{id}")]
    public IActionResult UploadFile(IFormFile file,long id)
    {
        _lectureManager.AddFileAsync(file,id);
        return Ok("File Uploaded Successfully");
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getAllFiles")]
    public ActionResult<List<UploadLectureFileDto>> GetAllFiles()
    {
        return _lectureManager.GetAllFiles()!;
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getFile/{id}")]
    public IActionResult GetFile(int id)
    {
        var file = _lectureManager.GetFile(id);
        if (file == null) return NotFound();
        return File(file.Content,file.Extension);
    }
    
    [HttpDelete("deleteFile/{id}")]
    public IActionResult DeleteFile(int id)
    {
        _lectureManager.DeleteFile(id);
        return Ok();
    }
    
    [HttpPut("updateFile/{id}")]
    public IActionResult UpdateFile(int id, IFormFile file)
    {
        _lectureManager.UpdateFileAsync(id,file);
        return Ok("File Updated Successfully");
    }
}