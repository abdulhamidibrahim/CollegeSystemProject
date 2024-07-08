namespace CollegeSystem.DL;

public interface IMeetingManager
{
    public void Add(MeetingAddDto meetingAddDto);
    public void Update(MeetingUpdateDto meetingUpdateDto);
    public void Delete(long id);
    public MeetingReadDto? Get(long id);
    public List<MeetingReadDto> GetAll();
    
    public List<MeetingReadDto> GetAllByGroupId(long groupId);
}