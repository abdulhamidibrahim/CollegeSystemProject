using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.DAL.Models;

public class Submission
{
    public int SubmissionId { get; set; }
    public int QuizId { get; set; }
    
    [ForeignKey(nameof(Student))]
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime SubmittedOn { get; set; }
    
    [Precision(2)]
    public decimal Score { get; set; }
    public ICollection<Answer> Answers { get; set; }
}