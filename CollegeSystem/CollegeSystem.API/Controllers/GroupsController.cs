using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController: ControllerBase
{
    private readonly IGroupManager _groupManager;

    public GroupsController(IGroupManager groupManager)
    {
        _groupManager = groupManager;
    }
    
    [HttpGet("getGroups/{courseId}")]
    public ActionResult<List<GroupReadDto>> GetAll(long courseId)
    {
        try
        {
            var result =_groupManager.GetAll(courseId);   
            return Ok(result);
        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<GroupReadDto?> Get(long id)
    {
        var group = _groupManager.Get(id);
        if (group == null) return NotFound(new { message = "group not found"});
        return group;
    }
    
    [HttpPost]
    public ActionResult Add(GroupAddDto groupAddDto)
    {
        _groupManager.Add(groupAddDto);
        return Ok(new { message = "group added"});
    }
    
    [HttpPut]
    public ActionResult Update(GroupUpdateDto groupUpdateDto)
    {
        _groupManager.Update(groupUpdateDto);
        return Ok(new { message = "group updated"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _groupManager.Delete(id);
        return Ok(new { message = "group deleted"});
    }
    
}