namespace CollegeSystem.DL;

public interface IReplyManager
{
    public void Add(ReplyAddDto replyAddDto);
    public void Update(ReplyUpdateDto replyUpdateDto);
    public void Delete(long id);
    public ReplyReadDto? Get(long id);
    public List<ReplyReadDto> GetAll();
    public List<ReplyReadDto>? GetByPostId(long id);
}