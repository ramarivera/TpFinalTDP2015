using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class UserAnswerCreactionData
    {
        public int Id { get; set; }
        public QuestionData Question { get; set; }
        public AnswerSessionData AnswerSession { get; set; }
        public AnswerData ChosenAnswer { get; set; }
        public bool AnswerStatus { get; set; }
    }
}
