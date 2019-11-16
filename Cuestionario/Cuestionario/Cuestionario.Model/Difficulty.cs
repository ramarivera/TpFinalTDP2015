using System.Collections.Generic;

namespace Questionnaire.Model
{
    /// <summary>
    /// Represents the Difficulty to which a <see cref="Model.Question"/> belongs
    /// </summary>
    // TODO review if, since diff and cat both have a list of questions, an specification patter 
    // would be of any use
    public class Difficulty
    {
        private readonly ICollection<Question> questions;

        public Difficulty()
        {
            questions = new List<Question>();
        }
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual IEnumerable<Question> Questions => questions;
    }
    
}
