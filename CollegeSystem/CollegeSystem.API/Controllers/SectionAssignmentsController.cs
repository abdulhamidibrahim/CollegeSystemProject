using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionAssignmentsController: ControllerBase
{
    private readonly ISectionAssignmentManager _sectionAssignmentManager;

    public SectionAssignmentsController(ISectionAssignmentManager sectionAssignmentManager)
    {
        _sectionAssignmentManager = sectionAssignmentManager;
    }
    
    [HttpGet]
    public ActionResult<List<SectionAssignmentReadDto>> GetAll()
    {
        return _sectionAssignmentManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<SectionAssignmentReadDto?> Get(long id)
    {
        var user = _sectionAssignmentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(SectionAssignmentAddDto sectionAssignmentAddDto)
    {
        _sectionAssignmentManager.Add(sectionAssignmentAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(SectionAssignmentUpdateDto sectionAssignmentUpdateDto)
    {
        _sectionAssignmentManager.Update(sectionAssignmentUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(SectionAssignmentDeleteDto sectionAssignmentDeleteDto)
    {
        _sectionAssignmentManager.Delete(sectionAssignmentDeleteDto);
        return Ok();
    }
    
}