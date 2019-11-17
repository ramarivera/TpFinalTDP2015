using System.Collections.Generic;

namespace Questionnaire.Model
{
    /// <summary>
    /// Represents the Category to which a <see cref="Model.Question"/> belongs
    /// </summary>
    public class Category : BaseEntity
    {
        private readonly ICollection<Question> questions;

        public Category()
        {
            questions = new List<Question>();
        }

        public virtual string Description { get; set; }

        public virtual IEnumerable<Question> Questions => questions;
    }
}
