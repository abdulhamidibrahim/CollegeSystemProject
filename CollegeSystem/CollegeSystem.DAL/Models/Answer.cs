using System;
using System.Collections.Generic;

namespace CollegeSystem.DAL.Models;

public partial class Answer
{
    public int AnswerId { get; set; }
    
    public int SubmissionId { get; set; }
    public int QuestionId{ get; set; }
    public int SelectedOptionId { get; set; }
    public Submission Submission { get; set; }
    public Question Question { get; set; }
    public Option SelectedOption { get; set; }
    
}
