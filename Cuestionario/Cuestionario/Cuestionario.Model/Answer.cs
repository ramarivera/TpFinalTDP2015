namespace Questionnaire.Model
{
    /// <summary>
    /// Represents an answer to a certain question
    /// </summary>
    public class Answer : BaseEntity
    {
        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }
    }
}
