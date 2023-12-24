namespace CollegeSystem.DL;

public interface ILectureManager
{
    public void Add(LectureAddDto lectureAddDto);
    public void Update(LectureUpdateDto lectureUpdateDto);
    public void Delete(LectureDeleteDto lectureDeleteDto);
    public LectureReadDto? Get(long id);
    public List<LectureReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}