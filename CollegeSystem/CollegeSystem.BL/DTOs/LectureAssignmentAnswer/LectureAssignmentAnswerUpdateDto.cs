namespace CollegeSystem.DL;

public class LectureAssignmentAnswerUpdateDto
    {
    public long LectureAssignmentAnswerId { get; set; }

    public string? File { get; set; }

    public long? LectureAssignmentId { get; set; }

    public long? UserId { get; set; }
}

