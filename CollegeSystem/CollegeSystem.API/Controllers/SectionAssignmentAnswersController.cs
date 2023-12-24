using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionAssignmentAnswersController: ControllerBase
{
    private readonly ISectionAssignmentAnswerManager _sectionAssignmentAnswerManager;

    public SectionAssignmentAnswersController(ISectionAssignmentAnswerManager sectionAssignmentAnswerManager)
    {
        _sectionAssignmentAnswerManager = sectionAssignmentAnswerManager;
    }
    
    [HttpGet]
    public ActionResult<List<SectionAssignmentAnswerReadDto>> GetAll()
    {
        return _sectionAssignmentAnswerManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<SectionAssignmentAnswerReadDto?> Get(long id)
    {
        var user = _sectionAssignmentAnswerManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(SectionAssignmentAnswerAddDto sectionAssignmentAnswerAddDto)
    {
        _sectionAssignmentAnswerManager.Add(sectionAssignmentAnswerAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(SectionAssignmentAnswerUpdateDto sectionAssignmentAnswerUpdateDto)
    {
        _sectionAssignmentAnswerManager.Update(sectionAssignmentAnswerUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(SectionAssignmentAnswerDeleteDto sectionAssignmentAnswerDeleteDto)
    {
        _sectionAssignmentAnswerManager.Delete(sectionAssignmentAnswerDeleteDto);
        return Ok();
    }
    
}