using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Reply
{
    public long ReplyId { get; set; }
    
    public long? PostId { get; set; }
    public long? StudentId { get; set; }
    public long? StaffId { get; set; }

    public string? Content { get; set; }

    public virtual Post? Post { get; set; }

    public virtual Student? Student { get; set; }
    public virtual Staff? Staff { get; set; }
    
}
