namespace CollegeSystem.DL;

public interface ISectionAssignmentAnswerManager
{
    public void Add(SectionAssignmentAnswerAddDto sectionAssignmentAnswerAddDto);
    public void Update(SectionAssignmentAnswerUpdateDto sectionAssignmentAnswerUpdateDto);
    public void Delete(SectionAssignmentAnswerDeleteDto sectionAssignmentAnswerDeleteDto);
    public SectionAssignmentAnswerReadDto? Get(long id);
    public List<SectionAssignmentAnswerReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}