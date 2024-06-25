using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class MeetingManager:IMeetingManager
{
    private readonly IMeetingRepo _meetingRepo;
    private readonly IUnitOfWork _unitOfWork;

    public MeetingManager(IMeetingRepo meetingRepo, IUnitOfWork unitOfWork)
    {
        _meetingRepo = meetingRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(MeetingAddDto meetingAddDto)
    {
        var meeting = new Meeting()
        {
           Title = meetingAddDto.Title,
           StartDate = meetingAddDto.StartDate,
           Url = meetingAddDto.Url
        };
        _meetingRepo.Add(meeting);
        _unitOfWork.CompleteAsync();
    }

    public void Update(MeetingUpdateDto meetingUpdateDto)
    {
        var meeting = _meetingRepo.GetById(meetingUpdateDto.Id);
        if (meeting == null) return;
        meeting.Title = meetingUpdateDto.Title;
        meeting.StartDate = meetingUpdateDto.StartDate;
        meeting.Url = meetingUpdateDto.Url;
        
        _meetingRepo.Update(meeting);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(MeetingDeleteDto meetingDeleteDto)
    {
        var meeting = _meetingRepo.GetById(meetingDeleteDto.Id);
        if (meeting == null) return;
        _meetingRepo.Delete(meeting);
        _unitOfWork.CompleteAsync();
    }

    public MeetingReadDto? Get(long id)
    {
        var meeting = _meetingRepo.GetById(id);
        if (meeting == null) return null;
        return new MeetingReadDto()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url
        };
    }

    public List<MeetingReadDto> GetAll()
    {
        var meetings = _meetingRepo.GetAll();
        return meetings.Select(meeting => new MeetingReadDto()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url
        }).ToList();
    }
}