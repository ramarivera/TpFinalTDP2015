using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class AnswerSessionDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public string Username { get; set; }
        public int AnswerTime { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public IList<UserAnswerDTO> UserAnswers { get; set; }
    }
}
