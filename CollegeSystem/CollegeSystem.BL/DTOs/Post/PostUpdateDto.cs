namespace CollegeSystem.DL;

public class PostUpdateDto
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Img { get; set; }

    public string? Content { get; set; }

    public long GroupId { get; set; }

}       
