using CollegeSystem.DL;
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

    [HttpGet]
    public ActionResult<List<AssignmentReadDto>> GetAll()
    {
        return _assignmentManager.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<AssignmentReadDto?> Get(long id)
    {
        var user = _assignmentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public ActionResult Add(AssignmentAddDto assignmentAddDto)
    {
        _assignmentManager.Add(assignmentAddDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(AssignmentUpdateDto assignmentUpdateDto)
    {
        _assignmentManager.Update(assignmentUpdateDto);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(AssignmentDeleteDto assignmentDeleteDto)
    {
        _assignmentManager.Delete(assignmentDeleteDto);
        return Ok();
    }

}