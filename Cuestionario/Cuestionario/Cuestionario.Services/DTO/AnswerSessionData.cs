using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.DTO
{
    public class AnswerSessionData
    {
        public int Id { get; set; }
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public IList<UserAnswerData> UserAnswers { get; set; }
        public int SessionDuration
        {
            get
            {
                if (EndTime == null)
                {
                    return 0;
                }
                else
                {
                    return (int)(this.EndTime - this.StartTime).TotalSeconds;
                }       
            }
            set { }
        }
    }
}
