namespace CollegeSystem.DL;

public interface IGroupManager
{
    public void Add(GroupAddDto groupAddDto);
    public void Update(GroupUpdateDto groupUpdateDto);
    public void Delete(long id);
    public GroupReadDto? Get(long id);
    public List<GroupReadDto> GetAll(long courseId);
    // public UserReadDto Login(UserLoginDto userLoginDto);
}