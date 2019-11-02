namespace Questionnaire.Model
{
    public class Answer
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }
    }
}
