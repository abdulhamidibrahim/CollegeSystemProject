using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class MeetingManager:IMeetingManager
{
    private readonly IUnitOfWork _unitOfWork;

    public MeetingManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(MeetingAddDto meetingAddDto)
    {
        var meeting = new Meeting()
        {
           Title = meetingAddDto.Title,
           StartDate = meetingAddDto.StartDate,
           Url = meetingAddDto.Url,
           GroupId = meetingAddDto.GroupId,
        };
        _unitOfWork.Meeting.Add(meeting);
        _unitOfWork.CompleteAsync();
    }

    public void Update(MeetingUpdateDto meetingUpdateDto)
    {
        var meeting = _unitOfWork.Meeting.GetById(meetingUpdateDto.Id);
        if (meeting == null) return;
        meeting.Title = meetingUpdateDto.Title;
        meeting.StartDate = meetingUpdateDto.StartDate;
        meeting.Url = meetingUpdateDto.Url;
        meeting.GroupId = meetingUpdateDto.GroupId;
        
        _unitOfWork.Meeting.Update(meeting);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var meeting = _unitOfWork.Meeting.GetById(id);
        if (meeting == null) return;
        _unitOfWork.Meeting.Delete(meeting);
        _unitOfWork.CompleteAsync();
    }

    public MeetingReadDto? Get(long id)
    {
        var meeting = _unitOfWork.Meeting.GetById(id);
        if (meeting == null) return null;
        return new MeetingReadDto()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url,
            GroupId = meeting.GroupId
        };
    }

    public List<MeetingReadDto> GetAll()
    {
        var meetings = _unitOfWork.Meeting.GetAll();
        return meetings.Select(meeting => new MeetingReadDto()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url,
            GroupId = meeting.GroupId,
        }).ToList();
    }

    public List<MeetingReadDto> GetAllByGroupId(long groupId)
    {
        var meetings = _unitOfWork.Meeting.GetMeetingsByGroupId(groupId);
        return meetings.Select(meeting => new MeetingReadDto()
        {
            Id = meeting.Id,
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url,
            GroupId = meeting.GroupId,
        }).ToList();
    }
}