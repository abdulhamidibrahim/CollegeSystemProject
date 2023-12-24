namespace CollegeSystem.DL;

public interface ITempAttendanceManager
{
    public void Add(TempAttendanceAddDto tempAttendanceAddDto);
    public void Update(TempAttendanceUpdateDto tempAttendanceUpdateDto);
    public void Delete(TempAttendanceDeleteDto tempAttendanceDeleteDto);
    public TempAttendanceReadDto? Get(long id);
    public List<TempAttendanceReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}