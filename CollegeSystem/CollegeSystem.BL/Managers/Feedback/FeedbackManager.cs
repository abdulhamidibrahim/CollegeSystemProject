using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class FeedbackManager:IFeedbackManager
{
    private readonly IUnitOfWork _unitOfWork;

    public FeedbackManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(FeedbackAddDto feedbackAddDto)
    {
        var feedback = new Feedback()
        {
           Content = feedbackAddDto.Content,
           SectionId = feedbackAddDto.SectionId,
           LectureId = feedbackAddDto.LectureId,
           Date = feedbackAddDto.Date,
           StudentId = feedbackAddDto.StudentId,
           Stars = feedbackAddDto.Stars,
        };
        _unitOfWork.Feedback.Add(feedback);
        _unitOfWork.CompleteAsync();
    }

    public void Update(FeedbackUpdateDto feedbackUpdateDto)
    {
        var feedback = _unitOfWork.Feedback.GetById(feedbackUpdateDto.Id);
        if (feedback == null) return;
        
        feedback.Date = feedbackUpdateDto.Date;
        feedback.Content = feedbackUpdateDto.Content;
        feedback.SectionId = feedbackUpdateDto.SectionId;
        feedback.LectureId = feedbackUpdateDto.LectureId;
        feedback.StudentId = feedbackUpdateDto.StudentId;
        feedback.Stars = feedbackUpdateDto.Stars;
        
        _unitOfWork.Feedback.Update(feedback);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var feedback = _unitOfWork.Feedback.GetById(id);
        if (feedback == null) return;
        _unitOfWork.Feedback.Delete(feedback);
        _unitOfWork.CompleteAsync();
        
    }

    public FeedbackReadDto? Get(long id)
    {
        var feedback = _unitOfWork.Feedback.GetById(id);
        if (feedback == null) return null;
        return new FeedbackReadDto()
        {
            Id = feedback.Id,
            Date = feedback.Date,
            Content = feedback.Content,
            SectionId = feedback.SectionId,
            LectureId = feedback.LectureId,
            StudentId = feedback.StudentId,
            Stars = feedback.Stars,
            StudentName = _unitOfWork.Student.GetById(feedback.StudentId)?.UserName,
        };
    }

    public List<FeedbackReadDto> GetAll()
    {
        var feedbacks = _unitOfWork.Feedback.GetAll();
        return feedbacks.Select(feedback => new FeedbackReadDto()
        {
            Id = feedback.Id,
            Date = feedback.Date,
            Content = feedback.Content,
            SectionId = feedback.SectionId,
            LectureId = feedback.LectureId,
            StudentId = feedback.StudentId,
            Stars = feedback.Stars,
            
        }).ToList();
    }
}