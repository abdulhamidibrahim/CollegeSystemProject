using CollegeSystem.DL;
using FileUploadingWebAPI.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;


// [Authorize(Roles = "Assistant")]
[ApiController]
[Route("api/[controller]")]
public class SectionsController: ControllerBase
{
    private readonly ISectionManager _sectionManager;

    public SectionsController(ISectionManager sectionManager)
    {
        _sectionManager = sectionManager;
    }
    
    [HttpGet("getAll/{groupId}")]
    public ActionResult<List<SectionReadDto>> GetAll(long groupId)
    {
        return _sectionManager.GetAll(groupId);
    }
    
    // [HttpGet("{courseId}")]
    // public ActionResult<SectionReadDto?> Get(long courseId)
    // {
    //     var user = _sectionManager.Get(courseId);
    //     if (user == null) return NotFound(new {message = "Section Not Found", status = "error"});
    //     return user;
    // }
    
    [HttpPost]
    public ActionResult Add(SectionAddDto sectionAddDto)
    {
        _sectionManager.Add(sectionAddDto);
        return Ok(new {message = "Section Added Successfully", status = "success"});
    }
    
    [HttpPut]
    public ActionResult Update(SectionUpdateDto sectionUpdateDto)
    {
        _sectionManager.Update(sectionUpdateDto);
        return Ok(new {message = "Section Updated Successfully", status = "success"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _sectionManager.Delete(id);
        return Ok(new {message = "Section Deleted Successfully", status = "success"});
    }
    
    
    [HttpPost("uploadFile/{courseId}")]
    [FileValidator]
    public IActionResult UploadFile(IFormFile file,long id)
    {
        _sectionManager.AddFileAsync(file,id);
        return Ok(new {message ="File Uploaded Successfully", status = "success"});
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getFile/{courseId}")]
    public IActionResult GetFile(int id)
    {
        var file = _sectionManager.GetFile(id);
        if (file == null) return NotFound(new { message = "File Not Found", status = "error"});
        return File(file.Content,file.Extension);
    }
    
    [FileValidator]
    [HttpPut("{courseId}")]
    public IActionResult UpdateFile(int sectionId, IFormFile file)
    {
        _sectionManager.UpdateFileAsync(sectionId, file);

        return Ok(new { message = "File Updated Successfully", status = "success"});
    }
    
    [HttpDelete("deleteFile/{courseId}")]
    public IActionResult DeleteFile(int id)
    {
        _sectionManager.DeleteFile(id);

        return Ok(new { message = "File Deleted Successfully", status = "success" });
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("getAllFiles")]
    public ActionResult<List<UploadSectionFileDto>> GetAllFiles()
    {
        return _sectionManager.GetAllFiles();
    }
    
}