namespace CollegeSystem.DL;

public interface IFeedbackManager
{
    public void Add(FeedbackAddDto feedbackAddDto);
    public void Update(FeedbackUpdateDto feedbackUpdateDto);
    public void Delete(long id);
    public FeedbackReadDto? Get(long id);
    public List<FeedbackReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}