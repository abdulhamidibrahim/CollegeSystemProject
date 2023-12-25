﻿namespace CollegeSystem.DL;

public class LectureAssignmentUpdateDto
    {
    public long LectureAssignmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? File { get; set; }

    public long? LectureId { get; set; }
}
