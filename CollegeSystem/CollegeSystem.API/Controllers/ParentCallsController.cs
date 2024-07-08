using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentCallsController: ControllerBase
{
    private readonly IParentCallManager _parentCallManager;

    public ParentCallsController(IParentCallManager parentCallManager)
    {
        _parentCallManager = parentCallManager;
    }
    
    [HttpGet]
    public ActionResult<List<ParentCallReadDto>> GetAll()
    {
        return _parentCallManager.GetAll();
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<ParentCallReadDto?> Get(long id)
    {
        var parentCall = _parentCallManager.Get(id);
        if (parentCall == null) return NotFound(new { Message = "Parent Call not found"});
        return parentCall;
    }
    
    [HttpPost]
    public ActionResult Add(ParentCallAddDto parentCallAddDto)
    {
        _parentCallManager.Add(parentCallAddDto);
        return Ok(new { Message = "Parent Call added"});
    }
    
    [HttpPut]
    public ActionResult Update(ParentCallUpdateDto parentCallUpdateDto)
    {
        _parentCallManager.Update(parentCallUpdateDto);
        return Ok(new { Message = "Parent Call updated"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _parentCallManager.Delete(id);
        return Ok(new { Message = "Parent Call deleted"});
    }
    
}