using CollegeSystem.DL;
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

    [HttpGet]
    public ActionResult<List<AssignmentAnswerReadDto>> GetAll()
    {
        return _assignmentAnswerManager.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<AssignmentAnswerReadDto?> Get(long id)
    {
        var user = _assignmentAnswerManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public ActionResult Add(AssignmentAnswerAddDto assignmentAnswerAddDto)
    {
        _assignmentAnswerManager.Add(assignmentAnswerAddDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(AssignmentAnswerUpdateDto assignmentAnswerUpdateDto)
    {
        _assignmentAnswerManager.Update(assignmentAnswerUpdateDto);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(AssignmentAnswerDeleteDto assignmentAnswerDeleteDto)
    {
        _assignmentAnswerManager.Delete(assignmentAnswerDeleteDto);
        return Ok();
    }

}