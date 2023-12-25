using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSystem.DAL.Models;

[Table("Parent")]
public partial class Parent : ApplicationUser
{
    [RegularExpression(@"^[0-9\u0600-\u06FF\s]+$", 
        ErrorMessage ="Enter Arabic characters and Numeric")]
    public string? Name { get; set; }
    
    public string? Address { get; set; }
    public string Phone { get; set; } = null!;
}
