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

        return File(fileModel.FileContent, "application/octet-stream", fileModel.FileName);
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

    [Authorize(Roles = "Staff")]
    [HttpPut("UpdateFile/{id}")]
    public IActionResult UpdateFile(int id, IFormFile file)
    {
        _assignmentManager.UpdateAssignmentAsync(id, file);
        return Ok();
    }
    
    [HttpGet("GetAllSectionAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllSectionAssignments()
    {
        return _assignmentManager.GetAllSectionAssignments() ?? throw new InvalidOperationException();
    }
    
    [HttpGet("GetAllLectureAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllLectureAssignments()
    {
        return _assignmentManager.GetAllLectureAssignments() ?? throw new InvalidOperationException();
    }
    
    [HttpGet("GetAllCourseAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllCourseAssignments(long courseId)
    {
        return _assignmentManager.GetAllCourseAssignments(courseId) ?? throw new InvalidOperationException();
    }
    
}