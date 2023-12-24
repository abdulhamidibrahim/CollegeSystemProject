namespace CollegeSystem.DL;

public interface ILectureAssignmentManager
{
    public void Add(LectureAssignmentAddDto lectureAssignmentAddDto);
    public void Update(LectureAssignmentUpdateDto lectureAssignmentUpdateDto);
    public void Delete(LectureAssignmentDeleteDto lectureAssignmentDeleteDto);
    public LectureAssignmentReadDto? Get(long id);
    public List<LectureAssignmentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}