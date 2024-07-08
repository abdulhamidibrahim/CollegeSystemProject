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

    #region commented

    // [Authorize(Roles = "Assistant")]
    // [HttpPost("uploadSectionFileAssignment")]
    // public IActionResult UploadSectionAssignmentFile(IFormFile file,long assignmentId)
    // {
    //     if (file == null || file.Length == 0)
    //         return Content("file not selected");
    //     _assignmentManager.AddSectionAssignmentFileAsync(file,assignmentId);
    //
    //     return Ok("File Uploaded Successfully");
    // }
    //
    // [Authorize(Roles = "Teacher")]
    // [HttpPost("uploadLectureFileAssignment")]
    // public IActionResult UploadLectureFileAssignment(IFormFile file,long assignmentId)
    // {
    //     if (file == null || file.Length == 0)
    //         return Content("file not selected");
    //     _assignmentManager.AddLectureAssignmentFileAsync(file,assignmentId);
    //
    //     return Ok("File Uploaded Successfully");
    // }
    //
    // [Authorize(Roles = "Assistant")]
    // [HttpPost("AddSectionAssignment")]
    // public IActionResult AddSectionAssignment(SectionAssignmentAddDto assignmentAddDto)
    // {
    //     _assignmentManager.AddSectionAssignmentAsync(assignmentAddDto);
    //     return Ok();
    // }
    //
    // [Authorize(Roles = "Teacher")]
    // [HttpPost("AddLectureAssignment")]
    // public IActionResult AddLectureAssignment(LectureAssignmentAddDto assignmentAddDto)
    // {
    //     _assignmentManager.AddLectureAssignmentAsync(assignmentAddDto);
    //     return Ok();
    // }
    //
    //
    // [Authorize(Roles = "Student")]
    // [HttpGet("DownloadAssignment/{courseId}")]
    // public IActionResult DownloadFile(int courseId)
    // {
    //     var fileModel = _assignmentManager.GetAssignment(courseId);
    //     if (fileModel == null)
    //         return NotFound();
    //
    //     return File(fileModel.FileContent, "application/octet-stream", fileModel.FileName);
    // }
    //
    // // [HttpGet("list")]
    // // public IActionResult ListAssignment()
    // // {
    // //     var fileModels = _assignmentManager.GetAll();
    // //     return Ok(fileModels);
    // // }
    //
    // [Authorize(Roles = "Staff")]
    // [HttpDelete("DeleteFile/{courseId}")]
    // public IActionResult DeleteFile(int courseId)
    // {
    //     _assignmentManager.DeleteAssignment(courseId);
    //   
    //     return Ok();
    // }
    //
    // [Authorize(Roles = "Assistant")]
    // [HttpPut("UpdateSectionAssignment/{courseId}")]
    // public IActionResult UpdateSectionFile(int assignmentId, IFormFile file,DateTime deadline)
    // {
    //     _assignmentManager.UpdateAssignmentAsync(assignmentId, file,deadline);
    //     return Ok();
    // }
    //
    //
    // [Authorize(Roles = "Teacher")]
    // [HttpPut("UpdateLectureAssignment/{courseId}")]
    // public IActionResult UpdateLectureFile(int lectureId, IFormFile file,DateTime deadline)
    // {
    //     _assignmentManager.UpdateAssignmentAsync(lectureId, file,deadline);
    //     return Ok();
    // }
    //

    #endregion

    // [Authorize(Roles = "Student")]
    [HttpGet("GetAllSectionAssignments/{groupId}")]
    public ActionResult<List<AssignmentReadAllDto>> GetAllSectionAssignments(long groupId)
    {
        return _assignmentManager.GetAllSectionAssignments(groupId) ?? throw new InvalidOperationException();
    }

    // [Authorize(Roles = "Student")]
    [HttpGet("GetAllLectureAssignments/{groupId}")]
    public ActionResult<List<AssignmentReadAllDto>> GetAllLectureAssignments(long groupId)
    {
        return _assignmentManager.GetAllLectureAssignments(groupId) ?? throw new InvalidOperationException();
    }

    #region MyRegion

    // [Authorize(Roles = "Student")]
    // [HttpGet("GetAllCourseAssignments")]
    // public ActionResult<List<AssignmentReadDto>> GetAllCourseAssignments(long groupId)
    // {
    //     return _assignmentManager.GetAllCourseAssignments(groupId) ?? throw new InvalidOperationException();
    // }

    // [HttpGet("course/{groupId}")]
    // public async Task<IActionResult> GetAssignmentsByCourse(long groupId)
    // {
    //     var assignments = await _assignmentManager.GetAssignmentsByCourseAsync(groupId);
    //     return Ok(assignments);
    // }
    //
    // [HttpGet("{assignmentId}")]
    // public async Task<IActionResult> GetAssignmentById(long assignmentId)
    // {
    //     var assignment = await _assignmentManager.GetAssignmentByIdAsync(assignmentId);
    //     if (assignment == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(assignment);
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> AddAssignment(AssignmentAddDto assignment)
    // {
    //     await _assignmentManager.AddAssignmentAsync(assignment);
    //     return CreatedAtAction(nameof(GetAssignmentById), new { assignmentId = assignment.AssignmentId }, assignment);
    // }
    //
    // [HttpPut("{assignmentId}")]
    // public async Task<IActionResult> UpdateAssignment(long assignmentId, AssignmentUpdateDto assignment)
    // {
    //     if (assignmentId != assignment.AssignmentId)
    //     {
    //         return BadRequest();
    //     }
    //     await _assignmentManager.UpdateAssignmentAsync(assignment);
    //     return NoContent();
    // }
    //
    // [HttpDelete("{assignmentId}")]
    // public async Task<IActionResult> DeleteAssignment(long assignmentId)
    // {
    //     await _assignmentManager.DeleteAssignmentAsync(assignmentId);
    //     return NoContent();
    // }
    //
    // [HttpPost("submit")]
    // public async Task<IActionResult> SubmitAssignmentAnswer(AssignmentAnswerAddDto answer)
    // {
    //     await _assignmentManager.SubmitAssignmentAnswerAsync(answer);
    //     return Ok();
    // }

    #endregion


    [HttpGet("course/{groupId}")]
    public async Task<IActionResult> GetAssignmentsByCourseGroup(long groupId)
    {
        var assignments = await _assignmentManager.GetAssignmentsByCourseAsync(groupId);
        return Ok(assignments);
    }

    [HttpGet("download/{assignmentId}")]
    public async Task<IActionResult> GetAssignmentById(long assignmentId)
    {
        var assignment = await _assignmentManager.GetAssignmentByIdAsync(assignmentId);
        if (assignment == null)
        {
            return NotFound();
        }

        return File(assignment.FileContent, "application/octet-stream", assignment.FileName);   
    }

    // [Authorize("Staff")]
[HttpPost]
    public async Task<IActionResult> AddAssignment([FromForm] AssignmentAddDto assignment)
    {
        await _assignmentManager.AddAssignmentAsync(assignment);
        return Ok(new { message = "Assignment added successfully" });
        // return CreatedAtAction(nameof(GetAssignmentById), new { assignmentId = assignment.GroupId }, assignment);
    }

    [Authorize(Roles ="Staff")]
    [HttpPut("{assignmentId}")]
    public async Task<IActionResult> UpdateAssignment(long assignmentId, [FromBody] AssignmentUpdateDto assignment)
    {
        if (assignmentId != assignment.AssignmentId)
        {
            return BadRequest(new{ message = "Invalid assignment ID"});
        }
        await _assignmentManager.UpdateAssignmentAsync(assignment);
        return NoContent();
    }
    
    [Authorize(Roles ="Staff")]
    [Authorize]
    [HttpDelete("{assignmentId}")]
    public async Task<IActionResult> DeleteAssignment(long assignmentId)
    {
        await _assignmentManager.DeleteAssignmentAsync(assignmentId);
        return NoContent();
    }

    [Authorize(Roles ="Student")]
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitAssignmentAnswer([FromForm] IFormFile answer, long assignmentId, long studentId)
    {
        await _assignmentManager.SubmitAssignmentAnswerAsync(answer, assignmentId, studentId);
        return Ok(new { message = "Assignment answer submitted successfully"});
    }
    
    [Authorize(Roles="Student")]
    [HttpGet("openAssignment/{assignmentId}")]
    public async Task<IActionResult> GetAssignmentFiles(long assignmentId)
    {
        var files = await _assignmentManager.GetAssignmentFilesAsync(assignmentId);
        return Ok(files);
    }
}
    
