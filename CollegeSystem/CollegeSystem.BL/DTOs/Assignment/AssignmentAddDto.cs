namespace CollegeSystem.DL;
public class AssignmentAddDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
       
        public long? SectionId { get; set; }
        public long? LectureId { get; set; }
        public long? CourseId { get; set; }
        
    }

