using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.DTO
{
    public class AnswerSessionData
    {
        public int Id { get; set; }
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Username { get; set; }
        public int AnswerTime { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public IList<UserAnswerCreactionData> UserAnswers { get; set; }
    }
}
