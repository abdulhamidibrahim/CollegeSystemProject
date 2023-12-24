namespace CollegeSystem.DL;

public interface IReplyManager
{
    public void Add(ReplyAddDto replyAddDto);
    public void Update(ReplyUpdateDto replyUpdateDto);
    public void Delete(ReplyDeleteDto replyDeleteDto);
    public ReplyReadDto? Get(long id);
    public List<ReplyReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}