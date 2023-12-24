namespace CollegeSystem.DL;

public class ReplyUpdateDto
{
    public int ReplyId { get; set; }

    public long? UserId { get; set; }

    public int? PostId { get; set; }

    public string? Content { get; set; }

}       
