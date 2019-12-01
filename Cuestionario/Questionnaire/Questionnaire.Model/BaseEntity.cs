namespace Questionnaire.Model
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; }
    }
}
