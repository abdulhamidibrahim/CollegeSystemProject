using CollegeSystem.BL.DTOs.Submission;
using CollegeSystem.BL.Enums;
using CollegeSystem.BL.Utilities;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.DL;

public class QuizManager:IQuizManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserUtility _userUtility;

    public QuizManager(IUnitOfWork unitOfWork, UserUtility userUtility)
    {
        _unitOfWork = unitOfWork;
        _userUtility = userUtility;
    }

    #region Commented

    // public void Add(QuizAddDto quizAddDto)
    // {
    //     var quiz = new Quiz()
    //     {
    //         Name = quizAddDto.Name,
    //         Description = quizAddDto.Description,
    //         Instructor = quizAddDto.Instructor,
    //         MaxDegree = quizAddDto.MaxDegree,
    //         IsActive = quizAddDto.IsActive,
    //         StartDate = quizAddDto.StartDate,
    //         EndDate = quizAddDto.EndDate,
    //         MaxTime = quizAddDto.MaxTime,
    //         NumberOfQuestions = quizAddDto.NumberOfQuestions,
    //         // LectureId = quizAddDto.LectureId,
    //         // SectionId = quizAddDto.SectionId,
    //         GroupId = quizAddDto.GroupId,
    //     };
    //     _quizRepo.Add(quiz);
    //     _unitOfWork.CompleteAsync();
    // }
    //
    // public void Update(QuizUpdateDto quizUpdateDto)
    // {
    //     var quiz = _quizRepo.GetById(quizUpdateDto.QuizId);
    //     if (quiz == null) return;
    //     quiz.Name = quizUpdateDto.Name;
    //     quiz.Description = quizUpdateDto.Description;
    //     quiz.Instructor = quizUpdateDto.Instructor;
    //     quiz.MaxDegree = quizUpdateDto.MaxDegree;
    //     quiz.MaxTime = quizUpdateDto.MaxTime;
    //     quiz.GroupId = quizUpdateDto.GroupId;
    //     // quiz.SectionId = quizUpdateDto.SectionId;
    //     // quiz.LectureId = quizUpdateDto.LectureId;
    //     quiz.IsActive = quizUpdateDto.IsActive;
    //     quiz.QuizId = quizUpdateDto.QuizId;        
    //     quiz.StartDate = quizUpdateDto.StartDate;        
    //     quiz.EndDate = quizUpdateDto.EndDate;        
    //     quiz.NumberOfQuestions = quizUpdateDto.NumberOfQuestions;        
    //
    //     _quizRepo.Update(quiz);
    //     _unitOfWork.CompleteAsync();
    // }
    //
    // public void Delete(QuizDeleteDto quizDeleteDto)
    // {
    //     var quiz = _quizRepo.GetById(quizDeleteDto.GroupId);
    //     if (quiz == null) return;
    //     _quizRepo.Delete(quiz);
    //     _unitOfWork.CompleteAsync();
    // }

    // public QuizReadDto? Get(long courseId)
    // {
    //     var quiz = _quizRepo.GetById(courseId);
    //     if (quiz == null) return null;
    //     return new QuizReadDto()
    //     {
    //         GroupId = quiz.QuizId,
    //         Name = quiz.Name,
    //         Description = quiz.Description,
    //         Instructor = quiz.Instructor,
    //         MaxDegree = quiz.MaxDegree,
    //         MaxTime = quiz.MaxTime,
    //         IsActive = quiz.IsActive,
    //         StartDate = quiz.StartDate,
    //         EndDate = quiz.EndDate,
    //         NumberOfQuestions = quiz.NumberOfQuestions,
    //         SectionId = quiz.SectionId,
    //         LectureId = quiz.LectureId,
    //     };
    // }

    // public List<QuizReadDto> GetAll(long groupId)
    // {
    //     var quizs = _quizRepo.GetAll(groupId);
    //     return quizs.Select(quiz => new QuizReadDto()
    //     {
    //         GroupId = quiz.QuizId,
    //         Name = quiz.Name,
    //         Description = quiz.Description,
    //         Instructor = quiz.Instructor,
    //         MaxDegree = quiz.MaxDegree,
    //         MaxTime = quiz.MaxTime,
    //         IsActive = quiz.IsActive,
    //         StartDate = quiz.StartDate,
    //         EndDate = quiz.EndDate,
    //         NumberOfQuestions = quiz.NumberOfQuestions,
    //         SectionId = quiz.SectionId,
    //         LectureId = quiz.LectureId,
    //     }).ToList();
    // }
    
    // public QuizReadDto? GetByLectureId(long lectureId)
    // {
    //     var quiz = _quizRepo.GetByLectureId(lectureId);
    //     if (quiz == null) return null;
    //     return new QuizReadDto()
    //     {
    //         Name = quiz.Name,
    //         Description = quiz.Description,
    //         Instructor = quiz.Instructor,
    //         MaxDegree = quiz.MaxDegree,
    //         MaxTime = quiz.MaxTime,
    //         IsActive = quiz.IsActive,
    //         StartDate = quiz.StartDate,
    //         EndDate = quiz.EndDate,
    //         NumberOfQuestions = quiz.NumberOfQuestions,
    //         SectionId = quiz.SectionId,
    //         LectureId = quiz.LectureId,
    //     };
    // }
    
    // public QuizReadDto? GetBySectionId(long sectionId)
    // {
    //     var quiz = _quizRepo.GetBySectionId(sectionId);
    //     if (quiz == null) return null;
    //     return new QuizReadDto()
    //     {
    //         Name = quiz.Name,
    //         Description = quiz.Description,
    //         Instructor = quiz.Instructor,
    //         MaxDegree = quiz.MaxDegree,
    //         MaxTime = quiz.MaxTime,
    //         IsActive = quiz.IsActive,
    //         StartDate = quiz.StartDate,
    //         EndDate = quiz.EndDate,
    //         NumberOfQuestions = quiz.NumberOfQuestions,
    //         SectionId = quiz.SectionId,
    //         LectureId = quiz.LectureId,
    //     };
    // }

    // public void AddSectionQuiz(AddSectionQuizDto quizAddDto)
    // {
    //     var quiz = new Quiz()
    //     {
    //         Name = quizAddDto.Name,
    //         Description = quizAddDto.Description,
    //         Instructor = quizAddDto.Instructor,
    //         MaxDegree = quizAddDto.MaxDegree,
    //         MaxTime = quizAddDto.MaxTime,
    //         SectionId = quizAddDto.SectionId,
    //         IsActive = quizAddDto.IsActive,
    //         StartDate = quizAddDto.StartDate,
    //         EndDate = quizAddDto.EndDate,
    //         NumberOfQuestions = quizAddDto.NumberOfQuestions,
    //         
    //     };
    //     _quizRepo.Add(quiz);
    // }
    //
    // public void AddLectureQuiz(AddLectureQuizDto quizAddDto)
    // {
    //     var quiz = new Quiz()
    //     {
    //         Name = quizAddDto.Name,
    //         Description = quizAddDto.Description,
    //         Instructor = quizAddDto.Instructor,
    //         MaxDegree = quizAddDto.MaxDegree,
    //         MaxTime = quizAddDto.MaxTime,
    //         LectureId = quizAddDto.LectureId,
    //         IsActive = quizAddDto.IsActive,
    //         StartDate = quizAddDto.StartDate,
    //         EndDate = quizAddDto.EndDate,
    //         
    //         NumberOfQuestions = quizAddDto.NumberOfQuestions,
    //         
    //     };
    //     _quizRepo.Add(quiz);
    // }

    #endregion
    
   
    public List<QuizReadDto> GetAllSectionQuizzes(long groupId)
    {
        var quizzes = _unitOfWork.Quiz.GetAllSectionQuizzes(groupId);
        return quizzes!.Select(quiz => new QuizReadDto()
        {
            Id = quiz.QuizId,
            Name = quiz.Name,
            Description = quiz.Description,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            IsActive = quiz.IsActive,
            StartDate = quiz.StartDate,
            EndDate = quiz.EndDate,
            NumberOfQuestions = quiz.NumberOfQuestions,
            // SectionId = quiz.SectionId,
            // LectureId = quiz.LectureId,
        }).ToList();
    }
    
    public List<QuizReadDto> GetAllLectureQuizzes(long courseId)
    {
        var quizs = _unitOfWork.Quiz.GetAllLectureQuizzes(courseId);
        return quizs.Select(quiz => new QuizReadDto()
        {
            Name = quiz.Name,
            Description = quiz.Description,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            IsActive = quiz.IsActive,
            StartDate = quiz.StartDate,
            EndDate = quiz.EndDate,
            NumberOfQuestions = quiz.NumberOfQuestions,
            // SectionId = quiz.SectionId,
            // LectureId = quiz.LectureId,
        }).ToList();
    }
    
    
    ////////////////////
    /// public class QuizService

    public async Task<Quiz> CreateQuizAsync(QuizAddDto quizAddDto)
    {
        var quiz = new Quiz()
        {
            Name = quizAddDto.Name,
            Description = quizAddDto.Description,
            MaxTime = quizAddDto.MaxTime,
            IsActive = quizAddDto.IsActive,
            StartDate = quizAddDto.StartDate,
            EndDate = quizAddDto.EndDate,
            NumberOfQuestions = quizAddDto.NumberOfQuestions,
            GroupId = quizAddDto.GroupId,
            // LectureId = quizAddDto.LectureId,
            Questions = quizAddDto.Questions?.Select(q=>new Question()
            {
                Degree = q.Degree,
                QuestionText = q.QuestionText,
                Options = q.Options?.Select( o => new Option()
                {
                    Text = o.OptionText,
                    IsCorrect = o.IsCorrect,
                }).ToList(),
            }).ToList(),
        };
        quiz.Instructor = _userUtility.GetUserName();
        quiz.MaxDegree = quiz.Questions?.Sum(q => q.Degree);

        var staff = _unitOfWork.Staff.GetById(_userUtility.GetUserId());
        if (staff.IsAssistant)
        {
            quiz.QuizType = QuizType.section;
        }
        var result = await _unitOfWork.Quiz.CreateQuizAsync(quiz);
        await _unitOfWork.CompleteAsync();
        return result;
    }

    public async Task<Quiz> GetQuizByIdAsync(long quizId)
    {
        return await _unitOfWork.Quiz.GetQuizByIdAsync(quizId);
    }

    public async Task<List<Quiz>> GetActiveQuizzesAsync(long courseId)
    {
        return await _unitOfWork.Quiz.GetActiveQuizzesAsync(courseId)!;
    }

    public async Task<Quiz> UpdateQuizAsync(QuizUpdateDto quiz)
    {
        var quizToUpdate = await _unitOfWork.Quiz.GetQuizByIdAsync(quiz.QuizId);
        quizToUpdate.Name = quiz.Name;
        quizToUpdate.Instructor = _userUtility.GetUserName();
        quizToUpdate.MaxTime = quiz.MaxTime;
        quizToUpdate.IsActive = quiz.IsActive;
        quizToUpdate.StartDate = quiz.StartDate;
        quizToUpdate.EndDate = quiz.EndDate;
        quizToUpdate.NumberOfQuestions = quiz.NumberOfQuestions;
        quizToUpdate.Description = quiz.Description;
        
        quizToUpdate.MaxDegree = quiz.Questions?.Sum(q => q.Degree); 
        var result  =await _unitOfWork.Quiz.UpdateQuizAsync(quizToUpdate);
        await _unitOfWork.CompleteAsync();
        return result;
    }

    public async Task<bool> DeleteQuizAsync(long quizId)
    {
         var result = await _unitOfWork.Quiz.DeleteQuizAsync(quizId);
         await _unitOfWork.CompleteAsync();
         return result;
    }

    public async Task<Submission> SubmitQuizAsync(SubmissionDto submissionDto)
    {
        var submission = new Submission()
        {
            QuizId = submissionDto.QuizId,
            StudentId = submissionDto.StudentId,
            SubmittedOn = DateTime.Now
        };
 
        submission.Score = await CalculateScoreAsync(submissionDto);
        var result = await _unitOfWork.Quiz.SubmitQuizAsync(submission);
        await _unitOfWork.CompleteAsync();
        return result;
    }

    private async Task<decimal> CalculateScoreAsync(SubmissionDto submissionDto)
    {
        var submission = new Submission()
        {
            QuizId = submissionDto.QuizId,
            StudentId = submissionDto.StudentId,
            SubmittedOn = DateTime.Now
        };
        return await _unitOfWork.Quiz.CalculateScoreAsync(submission);
    }
}
