﻿using CollegeSystem.DAL.Models;

namespace CollegeSystem.DL;

public class ActivAllQuizAddDto
{


    public long? AllQuizzesId { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual AllQuiz? AllQuizzes { get; set; }
}


