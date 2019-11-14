using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.DTO
{
    public class UserAnswerCreationData
    {
        public QuestionData Question { get; set; }
        public AnswerSessionData AnswerSession { get; set; }
        public AnswerData ChosenAnswer { get; set; }
        public bool AnswerStatus { get; set; }
    }
}
