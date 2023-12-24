using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class ParentCall
{
    public long MessageId { get; set; }

    public string? Message { get; set; }

    public string? File { get; set; }

    public string? ParentEmail { get; set; }
}
