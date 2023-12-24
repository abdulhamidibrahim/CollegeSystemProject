using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string? Name { get; set; }

    public string? HeadOfDepartment { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Student> Users { get; set; } = new List<Student>();
}
