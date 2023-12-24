namespace CollegeSystem.DL;

public interface ICourseStaffManager
{
    public void Add(CourseStaffAddDto courseStaffAddDto);
    public void Update(CourseStaffUpdateDto courseStaffUpdateDto);
    public void Delete(CourseStaffDeleteDto courseStaffDeleteDto);
    public CourseStaffReadDto? Get(long id);
    public List<CourseStaffReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}