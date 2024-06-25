namespace CollegeSystem.DL;

    public class CourseUserReadDto
    {
        public long Id { get; set; }
        public string? Degree { get; set; }

        public long? CourseId { get; set; }

        public long? UserId { get; set; }
    }

