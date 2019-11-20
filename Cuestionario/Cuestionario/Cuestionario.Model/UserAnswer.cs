namespace Questionnaire.Model
{
    /// <summary>
    /// Represents each User Answer during a Questionnaire's <see cref="Model.AnswerSession"/>
    /// </summary>
    public class UserAnswer
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual AnswerSession AnswerSession { get; set; }

        public virtual Answer ChosenAnswer { get; set; }

        public virtual bool IsAnswerCorrect
        {
            get
            {
                return (ChosenAnswer.Id == Question.CorrectAnswer.Id);
            }
            set
            {
                // TODO ver si iría algo acá
            }
        }
        
    }
}
