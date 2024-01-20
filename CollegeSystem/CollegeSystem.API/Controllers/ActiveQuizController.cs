using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FCISystem.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActiveQuizController : ControllerBase
{
    private readonly IActiveQuizManager _activeQuizManager;

    public ActiveQuizController(IActiveQuizManager activeQuizManager)
    {
        _activeQuizManager = activeQuizManager;
    }

    [HttpGet]
    public ActionResult<List<ActiveQuizReadDto>> GetAll()
    {
        return _activeQuizManager.GetAll();
    }

    [HttpGet("{quizId}")]
    public ActionResult<ActiveQuizReadDto?> Get(long id)
    {
        var dto = _activeQuizManager.Get(id);

        if (dto == null)
        {
            return NotFound();
        }

        return dto;
    }
    [HttpPost]
    public ActionResult Add(ActiveQuizAddDto activeQuizAddDto)
    {
        _activeQuizManager.Add(activeQuizAddDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(ActiveQuizUpdateDto activeQuizUpdateDto)
    {
        _activeQuizManager.Update(activeQuizUpdateDto);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(ActiveQuizDeleteDto activeQuizDeleteDto)
    {
        _activeQuizManager.Delete(activeQuizDeleteDto);
        return Ok();
    }
    
    [HttpGet("GetAllSectionQuizzes")]
    public ActionResult<List<ActiveQuizReadDto>> GetAllSectionQuizzes()
    {
        return _activeQuizManager.GetAllSectionQuizzes();
    }
    
    [HttpGet("GetAllLectureQuizzes")]
    public ActionResult<List<ActiveQuizReadDto>> GetAllLectureQuizzes()
    {
        return _activeQuizManager.GetAllLectureQuizzes();
    }
}

