using Questionnaire.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Model
{
    /// <summary>
    /// Represents a Questionnaire's Answer Session, where a user answers many <see cref="Model.Question"/>
    /// </summary>
    public class AnswerSession : BaseEntity
    {
        private readonly ICollection<UserAnswer> answers;

        public AnswerSession()
        {
            answers = new List<UserAnswer>();
        }

        public virtual Category Category { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        public virtual QuestionSource QuestionSource { get; set; }

        public virtual string Username { get; set; }

        public virtual double Score { get; set; }

        public virtual DateTime StartTime { get; set; }

        public virtual DateTime? EndTime { get; set; }

        public virtual IEnumerable<UserAnswer> Answers => answers;

        public virtual int? CalculateDuration()
        {
            if (EndTime is DateTime lEndTime)
            {
                return Convert.ToInt32((lEndTime - StartTime).TotalSeconds);
            }

            return null;
        }

        public virtual double CalculateScore()
        {
            int lDifficultyFactor = this.Difficulty.DifficultyFactor;
            int lTimeFactor = this.CalculateTimeFactor();

            double lAnswersCount = this.Answers.Count();
            double lCorrectAnswersCount = this.Answers.Where(x => x.IsAnswerCorrect).Count();

            double lSessionScore = (lCorrectAnswersCount / lAnswersCount) * lDifficultyFactor * lTimeFactor;

            return lSessionScore;
        }

        /// <summary>
        /// Calculates the score per answer based on the total duration and amount of questions of the given <see cref="AnswerSession"/>
        /// </summary>
        /// <returns><see cref="AnswerSession"/> time factor</returns>
        private int CalculateTimeFactor()
        {
            int lTimeFactor = 0;
            double lSessionDuration = (this.EndTime - this.StartTime).Value.TotalSeconds;
            double lTimePerQuestion = (this.Answers.Count() / lSessionDuration);

            if (lTimePerQuestion < 5)
            {
                lTimeFactor = 5;
            }
            else if (lTimePerQuestion >= 5 && lTimePerQuestion <= 20)
            {
                lTimeFactor = 5;
            }
            else if (lTimePerQuestion > 20)
            {
                lTimeFactor = 1;
            }

            return lTimeFactor;
        }
    }
}
