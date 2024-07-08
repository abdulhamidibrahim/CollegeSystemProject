using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FCISystem.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActiveAllQuizController : ControllerBase
{
    private readonly IActiveAllQuizManager _activeAllQuizManager;

    public ActiveAllQuizController(IActiveAllQuizManager activeAllQuizManager)
    {
        _activeAllQuizManager = activeAllQuizManager;
    }

    [HttpGet]
    public ActionResult<List<ActivAllQuizReadDto>> GetAll()
    {
        return _activeAllQuizManager.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<ActivAllQuizReadDto?> Get(long id)
    {
        var user = _activeAllQuizManager.Get(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
    [HttpPost]
    public ActionResult Add(ActivAllQuizAddDto activeAllQuizAddDto)
    {
        _activeAllQuizManager.Add(activeAllQuizAddDto);
        return Ok();
    }

    [HttpPut]
    public ActionResult Update(ActivAllQuizUpdateDto activeAllQuizUpdateDto)
    {
        _activeAllQuizManager.Update(activeAllQuizUpdateDto);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(ActiveAllQuizDeleteDto activeAllQuizDeleteeDto)
    {
        _activeAllQuizManager.Delete(activeAllQuizDeleteeDto);
        return Ok();
    }

}
