﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class DifficultyDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
    }
}
