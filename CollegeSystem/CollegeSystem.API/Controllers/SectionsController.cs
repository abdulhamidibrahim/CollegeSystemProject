using CollegeSystem.DL;
using FileUploadingWebAPI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionsController: ControllerBase
{
    private readonly ISectionManager _sectionManager;

    public SectionsController(ISectionManager sectionManager)
    {
        _sectionManager = sectionManager;
    }
    
    [HttpGet]
    public ActionResult<List<SectionReadDto>> GetAll()
    {
        return _sectionManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<SectionReadDto?> Get(long id)
    {
        var user = _sectionManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(SectionAddDto sectionAddDto)
    {
        _sectionManager.Add(sectionAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(SectionUpdateDto sectionUpdateDto)
    {
        _sectionManager.Update(sectionUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(SectionDeleteDto sectionDeleteDto)
    {
        _sectionManager.Delete(sectionDeleteDto);
        return Ok();
    }
    
    
    
    [HttpPost("uploadFile/{id}")]
    // [FileValidator]
    public IActionResult UploadFile(IFormFile iamge,long id)
    {
        _sectionManager.AddFileAsync(iamge,id);
        return Ok();
    }
    
    
    [HttpPut("{id}")]
    public IActionResult UpdateFile(int sectionId, IFormFile file)
    {
        _sectionManager.UpdateFileAsync(sectionId, file);

        return Ok("Image Updated Successfully");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteFile(int id)
    {
        _sectionManager.DeleteFile(id);

        return Ok("Image Updated Successfully");
    }
    
}