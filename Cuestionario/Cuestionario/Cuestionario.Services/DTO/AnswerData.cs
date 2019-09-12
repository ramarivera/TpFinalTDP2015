using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class AnswerData
    {
        public int Id { get; set; }
        public QuestionData Question { get; set; }
        public string Description { get; set; }
        public bool Correct { get; set; }
    }
}
