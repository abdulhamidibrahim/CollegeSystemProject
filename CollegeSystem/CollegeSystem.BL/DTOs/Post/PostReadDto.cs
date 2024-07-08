using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class PostReadDto
{
    public long Id { get; set; }
    public string? Title { get; set; }

    // public string? Img { get; set; }

    public string? Content { get; set; }

    public long? GroupId { get; set; }
    
    // public Group? Group { get; set; }


}