using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LecturesController: ControllerBase
{
    private readonly ILectureManager _lectureManager;

    public LecturesController(ILectureManager lectureManager)
    {
        _lectureManager = lectureManager;
    }
    
    [HttpGet]
    public ActionResult<List<LectureReadDto>> GetAll()
    {
        return _lectureManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<LectureReadDto?> Get(long id)
    {
        var user = _lectureManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(LectureAddDto lectureAddDto)
    {
        _lectureManager.Add(lectureAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(LectureUpdateDto lectureUpdateDto)
    {
        _lectureManager.Update(lectureUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(LectureDeleteDto lectureDeleteDto)
    {
        _lectureManager.Delete(lectureDeleteDto);
        return Ok();
    }
    
}