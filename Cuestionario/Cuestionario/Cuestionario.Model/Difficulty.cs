using System.Collections.Generic;

namespace Questionnaire.Model
{
    // TODO review if, since diff and cat both have a list of questions, an specification patter 
    // would be of any use
    public class Difficulty
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Question> Questions { get; set; }
    }
    
}
