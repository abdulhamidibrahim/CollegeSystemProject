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
    
    [Authorize(Roles = "Assistant")]
    [HttpPost("uploadSectionFileAssignment")]
    public IActionResult UploadSectionAssignmentFile(IFormFile file,long assignmentId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
        _assignmentManager.AddSectionAssignmentFileAsync(file,assignmentId);

        return Ok("File Uploaded Successfully");
    }
    
    [Authorize(Roles = "Teacher")]
    [HttpPost("uploadLectureFileAssignment")]
    public IActionResult UploadLectureFileAssignment(IFormFile file,long assignmentId)
    {
        if (file == null || file.Length == 0)
            return Content("file not selected");
        _assignmentManager.AddLectureAssignmentFileAsync(file,assignmentId);

        return Ok("File Uploaded Successfully");
    }
    
    [Authorize(Roles = "Assistant")]
    [HttpPost("AddSectionAssignment")]
    public IActionResult AddSectionAssignment(SectionAssignmentAddDto assignmentAddDto)
    {
        _assignmentManager.AddSectionAssignmentAsync(assignmentAddDto);
        return Ok();
    }
    
    [Authorize(Roles = "Teacher")]
    [HttpPost("AddLectureAssignment")]
    public IActionResult AddLectureAssignment(LectureAssignmentAddDto assignmentAddDto)
    {
        _assignmentManager.AddLectureAssignmentAsync(assignmentAddDto);
        return Ok();
    }

    
    [Authorize(Roles = "Student")]
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

    [Authorize(Roles = "Assistant")]
    [HttpPut("UpdateSectionAssignment/{id}")]
    public IActionResult UpdateSectionFile(int assignmentId, IFormFile file,DateTime deadline)
    {
        _assignmentManager.UpdateAssignmentAsync(assignmentId, file,deadline);
        return Ok();
    }
    
    
    [Authorize(Roles = "Teacher")]
    [HttpPut("UpdateLectureAssignment/{id}")]
    public IActionResult UpdateLectureFile(int lectureId, IFormFile file,DateTime deadline)
    {
        _assignmentManager.UpdateAssignmentAsync(lectureId, file,deadline);
        return Ok();
    }
    
    [Authorize(Roles = "Assistant,Student")]
    [HttpGet("GetAllSectionAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllSectionAssignments()
    {
        return _assignmentManager.GetAllSectionAssignments() ?? throw new InvalidOperationException();
    }
    
    [Authorize(Roles = "Teacher, Student")]
    [HttpGet("GetAllLectureAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllLectureAssignments()
    {
        return _assignmentManager.GetAllLectureAssignments() ?? throw new InvalidOperationException();
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("GetAllCourseAssignments")]
    public ActionResult<List<AssignmentReadDto>> GetAllCourseAssignments(long courseId)
    {
        return _assignmentManager.GetAllCourseAssignments(courseId) ?? throw new InvalidOperationException();
    }
    
}