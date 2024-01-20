using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController: ControllerBase
{
    private readonly IQuizManager _quizManager;

    public QuizController(IQuizManager quizManager)
    {
        _quizManager = quizManager;
    }
    
    [HttpGet]
    public ActionResult<List<QuizReadDto>> GetAll(long courseId)
    {
        return _quizManager.GetAll(courseId);
    }
    
    [HttpGet("{id}")]
    public ActionResult<QuizReadDto?> Get(long id)
    {
        var quiz = _quizManager.Get(id);
        if (quiz == null) return NotFound();
        return quiz;
    }
    
    [HttpPost]
    public ActionResult Add(QuizAddDto quizAddDto)
    {
        _quizManager.Add(quizAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(QuizUpdateDto quizUpdateDto)
    {
        _quizManager.Update(quizUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(QuizDeleteDto quizDeleteDto)
    {
        _quizManager.Delete(quizDeleteDto);
        return Ok();
    }
    
    [HttpGet("GetAllSectionQuizzes")]
    public ActionResult<List<QuizReadDto>> GetAllSectionQuizzes(long courseId)
    {
        return _quizManager.GetAllSectionQuizzes(courseId);
    }
    
    [HttpGet("GetAllLectureQuizzes")]
    public ActionResult<List<QuizReadDto>> GetAllLectureQuizzes(long courseId)
    {
        return _quizManager.GetAllLectureQuizzes(courseId);
    }
    
    [HttpGet("GetByLectureId")]
    public ActionResult<QuizReadDto?> GetByLectureId(long lectureId)
    {
        var quiz = _quizManager.GetByLectureId(lectureId);
        if (quiz == null) return NotFound();
        return quiz;
    }
    
    [HttpGet("GetBySectionId")]
    public ActionResult<QuizReadDto?> GetBySectionId(long sectionId)
    {
        var quiz = _quizManager.GetBySectionId(sectionId);
        if (quiz == null) return NotFound();
        return quiz;
    }
    
}