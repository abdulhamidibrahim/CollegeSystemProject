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

    [HttpGet("{id}")]
    public ActionResult<ActiveQuizReadDto?> Get(long id)
    {
        var user = _activeQuizManager.Get(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
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
    public ActionResult Delete(ActiveQuizDeleteDto activeQuizDeleteeDto)
    {
        _activeQuizManager.Delete(activeQuizDeleteeDto);
        return Ok();
    }
}

