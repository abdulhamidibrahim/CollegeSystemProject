using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentAnswerController : ControllerBase
{
    private readonly IAssignmentAnswerManager _assignmentAnswerManager;

    public AssignmentAnswerController(IAssignmentAnswerManager assignmentAnswerManager)
    {
        _assignmentAnswerManager = assignmentAnswerManager;
    }
    
    
    
    // [Authorize(Roles = "Student")]
    [HttpPost]
    public IActionResult UploadFileAsync(IFormFile file, long assignmentId,long studentId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
    
        _assignmentAnswerManager.AddFileAsync(file,assignmentId,studentId);
        
    
        return Ok(new { file.Name });
    }
    
    [HttpPut]
    public IActionResult UpdateFileAsync(IFormFile file, long assignmentId,long studentId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
    
        _assignmentAnswerManager.UpdateFileAsync(assignmentId,studentId,file);
        
    
        return Ok(new { file.Name });
    }
   
    
    
    // [Authorize(Roles = "Staff")]
    [HttpGet("{id}")]
    public IActionResult Download(long assignmentId,long studentId)
    {
        var fileModel = _assignmentAnswerManager.GetFile(assignmentId,studentId);
        if (fileModel == null)
            return NotFound();
    
        return File(fileModel.Content, "application/octet-stream", fileModel.Name);
    }
    //
    [HttpGet]
    public IActionResult List()
    {
        var fileModels = _assignmentAnswerManager.GetAllFiles()?.Select(x => x.Name);
        return Ok(fileModels);
    }
    
    [Authorize(Roles = "Student")]
    [HttpDelete("{id}")]
    public IActionResult Delete(long assignmentId,long studentId)
    {
        var fileModel = _assignmentAnswerManager.GetFile(assignmentId,studentId);
        if (fileModel == null)
            return NotFound();
    
        
        _assignmentAnswerManager.DeleteFile(assignmentId,studentId);
      
        return Ok();
    }

}