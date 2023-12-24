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
    
    [HttpGet("{id}")]
    public ActionResult<DepartmentReadDto?> Get(long id)
    {
        var user = _departmentManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(DepartmentAddDto departmentAddDto)
    {
        _departmentManager.Add(departmentAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(DepartmentUpdateDto departmentUpdateDto)
    {
        _departmentManager.Update(departmentUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(DepartmentDeleteDto departmentDeleteDto)
    {
        _departmentManager.Delete(departmentDeleteDto);
        return Ok();
    }
    
}