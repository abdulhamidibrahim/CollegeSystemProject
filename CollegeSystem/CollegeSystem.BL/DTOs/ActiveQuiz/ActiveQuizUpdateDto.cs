﻿using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class ActiveQuizUpdateDto
{

    public int ActiveQuizzesId { get; set; }

    public long? QuizId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? Duration { get; set; }

}
