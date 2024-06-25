namespace CollegeSystem.DL;

public class ReplyReadDto
{
    public long Id { get; set; }
    
    public long? UserId { get; set; }

    public long? PostId { get; set; }

    public string? Content { get; set; }

}