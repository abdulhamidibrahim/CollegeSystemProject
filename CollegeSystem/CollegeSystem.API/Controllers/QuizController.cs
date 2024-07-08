using CollegeSystem.BL.DTOs.Submission;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
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

    #region commented
    
    //
    // [HttpGet]
    // public ActionResult<List<QuizReadDto>> GetAll(long groupId)
    // {
    //     return _quizManager.GetAll(groupId);
    // }
    //
    // [HttpGet("{courseId}")]
    // public ActionResult<QuizReadDto?> Get(long courseId)
    // {
    //     var quiz = _quizManager.Get(courseId);
    //     if (quiz == null) return NotFound();
    //     return quiz;
    // }
    
    // [Authorize(Roles = "Assistant")]
    // [HttpPost]
    // public ActionResult AddSectionQuiz(AddSectionQuizDto quizAddDto)
    // {
    //     _quizManager.AddSectionQuiz(quizAddDto);
    //     return Ok();
    // }
    //
    // [Authorize(Roles = "Teacher")]
    // [HttpPost]
    // public ActionResult AddLectureQuiz(AddLectureQuizDto quizAddDto)
    // {
    //     _quizManager.AddLectureQuiz(quizAddDto);
    //     return Ok();
    // }
    
    // [HttpPut]
    // public ActionResult Update(QuizUpdateDto quizUpdateDto)
    // {
    //     _quizManager.Update(quizUpdateDto);
    //     return Ok();
    // }
    
    // [HttpDelete]
    // public ActionResult Delete(QuizDeleteDto quizDeleteDto)
    // {
    //     _quizManager.Delete(quizDeleteDto);
    //     return Ok();
    // }
    
    #endregion
    
    [Authorize(Roles = "Assistant, Student")]
    [HttpGet("GetAllSectionQuizzes")]
    public ActionResult<List<QuizReadDto>> GetAllSectionQuizzes(long groupId)
    {
        return _quizManager.GetAllSectionQuizzes(groupId);
    }
    
    [Authorize(Roles = "Teacher,Student")]
    [HttpGet("GetAllLectureQuizzes")]
    public ActionResult<List<QuizReadDto>> GetAllLectureQuizzes(long groupId)
    {
        return _quizManager.GetAllLectureQuizzes(groupId);
    }
    
    // [Authorize(Roles = "Teacher,Student")]
    // [HttpGet("GetByLectureId")]
    // public ActionResult<QuizReadDto?> GetByLectureId(long lectureId)
    // {
    //     var quiz = _quizManager.GetByLectureId(lectureId);
    //     if (quiz == null) return NotFound();
    //     return quiz;
    // }
    
    // [Authorize(Roles = "Assistant, Student")]
    // [HttpGet("GetBySectionId")]
    // public ActionResult<QuizReadDto?> GetBySectionId(long sectionId)
    // {
    //     var quiz = _quizManager.GetBySectionId(sectionId);
    //     if (quiz == null) return NotFound();
    //     return quiz;
    // }
    ////////////
    ///
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizAddDto quiz)
    {
        var createdQuiz = await _quizManager.CreateQuizAsync(quiz);
        return CreatedAtAction(nameof(GetQuizById), new { quizId = createdQuiz.QuizId }, createdQuiz);
    }

    [HttpGet("{quizId}")]
    public async Task<IActionResult> GetQuizById(int quizId)
    {
        var quiz = await _quizManager.GetQuizByIdAsync(quizId);
        if (quiz == null)
        {
            return NotFound();
        }
        return Ok(quiz);
    }

    [HttpGet("active/{groupId}")]
    public async Task<IActionResult> GetActiveQuizzes(long groupId)
    {
        var quizzes = await _quizManager.GetActiveQuizzesAsync(groupId);
        return Ok(quizzes);
    }

    [HttpPut("{quizId}")]
    public async Task<IActionResult> UpdateQuiz(int quizId, [FromBody] QuizUpdateDto quiz)
    {
        if (quizId != quiz.QuizId)
        {
            return BadRequest();
        }

        var updatedQuiz = await _quizManager.UpdateQuizAsync(quiz);
        if (updatedQuiz == null)
        {
            return NotFound(new { message = "Quiz not found"});
        }
        return Ok(updatedQuiz);
    }

    [HttpDelete("{quizId}")]
    public async Task<IActionResult> DeleteQuiz(int quizId)
    {
        var success = await _quizManager.DeleteQuizAsync(quizId);
        if (!success)
        {
            return NotFound(new { message = "Quiz not found"});
        }
        return NoContent();
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitQuiz([FromBody] SubmissionDto submission)
    {
        var createdSubmission = await _quizManager.SubmitQuizAsync(submission);
        
        return Ok(new {  SubmissionID = createdSubmission.SubmissionId, Socre = createdSubmission.Score });
    }
}