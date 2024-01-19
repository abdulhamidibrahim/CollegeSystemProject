using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentManager _assignmentManager;

    public AssignmentController(IAssignmentManager assignmentManager)
    {
        _assignmentManager = assignmentManager;
    }
    
    // [Authorize(Roles = "Staff")]
    [HttpPost("uploadSectionAssignment")]
    public IActionResult UploadFile(IFormFile file,long sectionId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
        _assignmentManager.AddSectionAssignmentAsync(file,sectionId);

        return Ok("File Uploaded Successfully");
    }
    
    
    [HttpPost("uploadLectureAssignment")]
    public IActionResult UploadLectureAssignment(IFormFile file,long lectureId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
        _assignmentManager.AddLectureAssignmentAsync(file,lectureId);

        return Ok("File Uploaded Successfully");
    }

    
    // [Authorize(Roles = "Student")]
    [HttpGet("DownloadAssignment/{id}")]
    public IActionResult DownloadFile(int id)
    {
        var fileModel = _assignmentManager.GetAssignment(id);
        if (fileModel == null)
            return NotFound();

        return File(fileModel.Content, "application/octet-stream", fileModel.Name);
    }

    // [HttpGet("list")]
    // public IActionResult ListAssignment()
    // {
    //     var fileModels = _assignmentManager.GetAll();
    //     return Ok(fileModels);
    // }

    [Authorize(Roles = "Staff")]
    [HttpDelete("DeleteFile/{id}")]
    public IActionResult DeleteFile(int id)
    {
        _assignmentManager.DeleteAssignment(id);
      
        return Ok();
    }

}