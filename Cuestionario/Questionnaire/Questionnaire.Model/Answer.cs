namespace Questionnaire.Model
{
    /// <summary>
    /// Represents an Answer to a certain <see cref="Model.Question"/>
    /// </summary>
    public class Answer : BaseEntity
    {
        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }
    }
}
