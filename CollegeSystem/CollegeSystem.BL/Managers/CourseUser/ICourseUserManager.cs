namespace CollegeSystem.DL;

public interface ICourseUserManager
{
    public void Add(CourseUserAddDto courseUserAddDto);
    public void Update(CourseUserUpdateDto courseUserUpdateDto);
    public void Delete(CourseUserDeleteDto courseUserDeleteDto);
    public CourseUserReadDto? Get(long id);
    public List<CourseUserReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}