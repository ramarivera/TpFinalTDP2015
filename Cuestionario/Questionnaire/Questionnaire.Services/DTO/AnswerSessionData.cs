using System;
using System.Collections.Generic;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="AnswerSession"/> data transfer object
    /// </summary>
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
        
        /// <summary>
        /// Expressed in seconds
        /// </summary>
        public int SessionDuration
        {
            get
            {
                if (EndTime < StartTime)
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
