namespace Questionnaire.Model
{
    public class UserAnswer
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual AnswerSession AnswerSession { get; set; }

        public virtual Answer ChosenAnswer { get; set; }

        // TODO review how to get correct question answer
    }
}
