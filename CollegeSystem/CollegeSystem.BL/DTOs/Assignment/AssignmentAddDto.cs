using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;
public class AssignmentAddDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }

        public IEnumerable<IFormFile>? Files { get; set; }
        public long GroupId { get; set; }
    }

