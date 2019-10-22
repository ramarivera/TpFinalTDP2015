﻿using Cuestionario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IDifficultyHandler : IBaseHandler
    {
        IList<Difficulty> GetAll();
    }
}
