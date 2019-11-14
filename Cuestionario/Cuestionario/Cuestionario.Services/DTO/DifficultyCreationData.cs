using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.DTO
{
    public class DifficultyCreationData
    {
        public string Description { get; set; }
        public IList<QuestionData> Questions { get; set; }
    }
}
