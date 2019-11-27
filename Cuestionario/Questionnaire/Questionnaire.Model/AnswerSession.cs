using Questionnaire.Model.Enums;
using System;
using System.Collections.Generic;

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
    }
}
