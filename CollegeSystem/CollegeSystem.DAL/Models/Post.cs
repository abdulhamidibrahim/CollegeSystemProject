using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Post
{
    public long PostId { get; set; }

    public string? Title { get; set; }

    public string? Img { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

    public virtual ICollection<PostUser> PostUsers { get; set; } = new List<PostUser>();

    
}
