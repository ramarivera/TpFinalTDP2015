using Questionnaire.Model.Enums;
using System.Collections.Generic;

namespace Questionnaire.Model
{
    /// <summary>
    /// Represents the Difficulty to which a <see cref="Model.Question"/> belongs
    /// </summary>
    // TODO review if, since diff and cat both have a list of questions, an specification patter 
    // would be of any use
    public class Difficulty : BaseEntity
    {
        private static readonly IDictionary<string, DifficultyFactor> mDifficultyFactorMap = new Dictionary<string, DifficultyFactor>
        {
            { "easy", Enums.DifficultyFactor.Easy },
            { "medium", Enums.DifficultyFactor.Medium },
            { "hard", Enums.DifficultyFactor.Hard },
        };

        private readonly ICollection<Question> questions;

        public Difficulty()
        {
            questions = new List<Question>();
        }

        public virtual string Description { get; set; }

        public virtual IEnumerable<Question> Questions => questions;


        /// <summary>
        /// Retrieve a Difficulty Factor
        /// </summary>
        /// <param name="pDescription"></param>
        /// <returns></returns>
        public virtual int DifficultyFactor => (int)mDifficultyFactorMap[this.Description];
    }
}
