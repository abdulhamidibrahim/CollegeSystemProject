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
    
    [HttpGet("{id}")]
    public ActionResult<ParentCallReadDto?> Get(long id)
    {
        var user = _parentCallManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(ParentCallAddDto parentCallAddDto)
    {
        _parentCallManager.Add(parentCallAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(ParentCallUpdateDto parentCallUpdateDto)
    {
        _parentCallManager.Update(parentCallUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(ParentCallDeleteDto parentCallDeleteDto)
    {
        _parentCallManager.Delete(parentCallDeleteDto);
        return Ok();
    }
    
}