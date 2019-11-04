using System;
using System.Collections.Generic;

namespace Questionnaire.Model
{
    public class AnswerSession
    {
        private readonly ICollection<UserAnswer> answers;
        public AnswerSession()
        {
            answers = new List<UserAnswer>();
        }

        public virtual int Id { get; set; }

        public virtual Category Category { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        public virtual string Username { get; set; }

        // TODO add comment that the duration is in seconds
        public virtual int SessionDuration { get; set; }

        public virtual int Score { get; set; }

        public virtual DateTime StartTime { get; set; }

        public virtual IEnumerable<UserAnswer> Answers => answers;
    }
}
