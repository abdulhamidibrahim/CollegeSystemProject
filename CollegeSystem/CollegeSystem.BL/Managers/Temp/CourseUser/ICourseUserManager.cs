namespace CollegeSystem.DL;

public interface ICourseUserManager
{
    public void Add(CourseUserAddDto courseUserAddDto);
    public void Update(CourseUserUpdateDto courseUserUpdateDto);
    public void Delete(CourseUserDeleteDto courseUserDeleteDto);
    public CourseUserReadDto? Get(long id);
    public List<CourseUserReadDto> GetAll();

    public void RegisterCoursesForStudent(long[] coursesId, long studentId);

    public void UnRegisterCoursesForStudent(long[] coursesId, long studentId);
    
}