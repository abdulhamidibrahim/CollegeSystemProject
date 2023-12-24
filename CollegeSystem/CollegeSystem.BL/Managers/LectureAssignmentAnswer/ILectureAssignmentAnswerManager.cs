namespace CollegeSystem.DL;

public interface ILectureAssignmentAnswerManager
{
    public void Add(LectureAssignmentAnswerAddDto lectureAssignmentAnswerAddDto);
    public void Update(LectureAssignmentAnswerUpdateDto lectureAssignmentAnswerUpdateDto);
    public void Delete(LectureAssignmentAnswerDeleteDto lectureAssignmentAnswerDeleteDto);
    public LectureAssignmentAnswerReadDto? Get(long id);
    public List<LectureAssignmentAnswerReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}