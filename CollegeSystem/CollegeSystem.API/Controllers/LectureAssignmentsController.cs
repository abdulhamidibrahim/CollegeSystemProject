using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LectureAssignmentsController : ControllerBase
{
    private readonly ILectureAssignmentManager _lectureAssignmentManager;

    public LectureAssignmentsController(ILectureAssignmentManager lectureAssignmentManager)
    {
        _lectureAssignmentManager = lectureAssignmentManager;
    }
    [HttpGet]
    public ActionResult<List<LectureAssignmentReadDto>> GetAll()
    {
        return _lectureAssignmentManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<LectureAssignmentReadDto?> Get(long id)
    {
        var user = _lectureAssignmentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(LectureAssignmentAddDto lectureAssignmentAddDto)
    {
        _lectureAssignmentManager.Add(lectureAssignmentAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(LectureAssignmentUpdateDto lectureAssignmentUpdateDto)
    {
        _lectureAssignmentManager.Update(lectureAssignmentUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(LectureAssignmentDeleteDto lectureAssignmentDeleteDto)
    {
        _lectureAssignmentManager.Delete(lectureAssignmentDeleteDto);
        return Ok();
    }
}