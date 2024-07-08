
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FCISystem.DAL;

public class AssignmentRepo :GenericRepo<Assignment>,IAssignmentRepo
{
    private readonly CollegeSystemDbContext _context;

    public AssignmentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(long groupId)
        {
            return await _context.Assignments
                .Where(a => a.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(long assignmentId)
        {
            return await _context.Assignments
                .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(long assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SubmitAssignmentAnswerAsync(AssignmentAnswer answer)
        {
            _context.AssignmentAnswers.Add(answer);
            await _context.SaveChangesAsync();
        }

        public Task<List<AssignmentFile>> GetAssignmentFilesAsync(long assignmentId)
        {
            return _context.AssignmentFile
                .Where(f => f.AssignmentId == assignmentId)
                .ToListAsync();
        }
}

