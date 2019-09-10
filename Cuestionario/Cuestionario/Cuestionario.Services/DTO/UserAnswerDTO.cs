using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class UserAnswerDTO
    {
        public int Id { get; set; }
        public QuestionDTO Question { get; set; }
        public AnswerSessionDTO AnswerSession { get; set; }
        public AnswerDTO ChosenAnswer { get; set; }
        public bool AnswerStatus { get; set; }
    }
}
