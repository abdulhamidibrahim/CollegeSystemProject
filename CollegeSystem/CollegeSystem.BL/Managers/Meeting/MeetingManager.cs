using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class MeetingManager:IMeetingManager
{
    private readonly IMeetingRepo _meetingRepo;

    public MeetingManager(IMeetingRepo meetingRepo)
    {
        _meetingRepo = meetingRepo;
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
    }

    public void Update(MeetingUpdateDto meetingUpdateDto)
    {
        var meeting = _meetingRepo.GetById(meetingUpdateDto.Id);
        if (meeting == null) return;
        meeting.Title = meetingUpdateDto.Title;
        meeting.StartDate = meetingUpdateDto.StartDate;
        meeting.Url = meetingUpdateDto.Url;
        
        _meetingRepo.Update(meeting);
    }

    public void Delete(MeetingDeleteDto meetingDeleteDto)
    {
        var meeting = _meetingRepo.GetById(meetingDeleteDto.Id);
        if (meeting == null) return;
        _meetingRepo.Delete(meeting);
    }

    public MeetingReadDto? Get(long id)
    {
        var meeting = _meetingRepo.GetById(id);
        if (meeting == null) return null;
        return new MeetingReadDto()
        {
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
            Title = meeting.Title,
            StartDate = meeting.StartDate,
            Url = meeting.Url
        }).ToList();
    }
}