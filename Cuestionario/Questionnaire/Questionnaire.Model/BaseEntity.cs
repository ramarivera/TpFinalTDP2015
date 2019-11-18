namespace Questionnaire.Model
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual long Id { get; }
    }
}
