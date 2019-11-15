namespace Questionnaire.Model
{
    public class Answer : BaseEntity
    {
        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }
    }
}
