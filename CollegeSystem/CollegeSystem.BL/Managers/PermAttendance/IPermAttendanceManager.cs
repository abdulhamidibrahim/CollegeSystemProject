namespace CollegeSystem.DL;

public interface IPermAttendanceManager
{
    public void Add(PermAttendanceAddDto permAttendanceAddDto);
    public void Update(PermAttendanceUpdateDto permAttendanceUpdateDto);
    public void Delete(PermAttendanceDeleteDto permAttendanceDeleteDto);
    public PermAttendanceReadDto? Get(long id);
    public List<PermAttendanceReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}