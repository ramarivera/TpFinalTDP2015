﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.DTO
{
    public class DifficultyData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IList<QuestionData> Questions { get; set; }
    }
}
