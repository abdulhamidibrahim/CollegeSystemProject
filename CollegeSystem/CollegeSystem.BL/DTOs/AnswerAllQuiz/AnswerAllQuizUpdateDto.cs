﻿namespace CollegeSystem.DL;

public class AnswerAllQuizUpdateDto
{
    public long AnswerAllQuizzesId { get; set; }
    public string? StudentMark { get; set; }

    public long? UserId { get; set; }

    public long? AllQuizzesId { get; set; }

    public long? CourseId { get; set; }
}