using System.Collections.Generic;

namespace Questionnaire.Model
{
    public class Category
    {
        public virtual int Id { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Question> Questions { get; set; }
        // TODO replace by ienumerable
    }
}
