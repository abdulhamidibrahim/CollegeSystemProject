namespace CollegeSystem.DL;

public interface IMeetingManager
{
    public void Add(MeetingAddDto meetingAddDto);
    public void Update(MeetingUpdateDto meetingUpdateDto);
    public void Delete(MeetingDeleteDto meetingDeleteDto);
    public MeetingReadDto? Get(long id);
    public List<MeetingReadDto> GetAll();
    
}