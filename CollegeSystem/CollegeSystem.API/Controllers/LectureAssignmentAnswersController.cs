using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LectureAssignmentAnswersController : ControllerBase
{
    private readonly ILectureAssignmentAnswerManager _lectureAssignmentAnswerManager;

    public LectureAssignmentAnswersController(ILectureAssignmentAnswerManager lectureAssignmentAnswerManager)
    {
        _lectureAssignmentAnswerManager = lectureAssignmentAnswerManager;
    }
    [HttpGet]
    public ActionResult<List<LectureAssignmentAnswerReadDto>> GetAll()
    {
        return _lectureAssignmentAnswerManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<LectureAssignmentAnswerReadDto?> Get(long id)
    {
        var user = _lectureAssignmentAnswerManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(LectureAssignmentAnswerAddDto lectureAssignmentAnswerAddDto)
    {
        _lectureAssignmentAnswerManager.Add(lectureAssignmentAnswerAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(LectureAssignmentAnswerUpdateDto lectureAssignmentAnswerUpdateDto)
    {
        _lectureAssignmentAnswerManager.Update(lectureAssignmentAnswerUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(LectureAssignmentAnswerDeleteDto lectureAssignmentAnswerDeleteDto)
    {
        _lectureAssignmentAnswerManager.Delete(lectureAssignmentAnswerDeleteDto);
        return Ok();
    }
}