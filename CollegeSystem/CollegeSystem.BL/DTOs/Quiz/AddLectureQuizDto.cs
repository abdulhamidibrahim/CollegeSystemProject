namespace CollegeSystem.DL;

public class AddLectureQuizDto
{
    public string? Name { get; set; }

    public string? Instructor { get; set; }

    public string? MaxDegree { get; set; }

    public string? MaxTime { get; set; }

    public long? CourseId { get; set; }
    public long? LectureId { get; set; }
}