using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController: ControllerBase
{
    private readonly IDepartmentManager _departmentManager;

    public DepartmentsController(IDepartmentManager departmentManager)
    {
        _departmentManager = departmentManager;
    }
    
    [HttpGet]
    public ActionResult<List<DepartmentReadDto>> GetAll()
    {
        return _departmentManager.GetAll();
    }
    
    [HttpGet("{courseId}")]
    public ActionResult<DepartmentReadDto?> Get(long id)
    {
        var dept = _departmentManager.Get(id);
        if (dept == null) return NotFound(new {message="Department Not Found"});
        return dept;
    }
    
    [HttpPost]
    public ActionResult Add(DepartmentAddDto departmentAddDto)
    {
        _departmentManager.Add(departmentAddDto);
        return Ok(new {message= "Added successfully"});
    }
    
    [HttpPut]
    public ActionResult Update(DepartmentUpdateDto departmentUpdateDto)
    {
        _departmentManager.Update(departmentUpdateDto);
        return Ok(new {message = "Updated successfully"});
    }
    
    [HttpDelete("{courseId}")]
    public ActionResult Delete(long id)
    {
        _departmentManager.Delete(id);
        return Ok(new {message = "deleted successfully"});
    }
    
}