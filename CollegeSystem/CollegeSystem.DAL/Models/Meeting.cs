using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Meeting
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Url { get; set; }
    public Group Group { get; set; }
    public long GroupId { get; set; }
}
