using Questionnaire.Model;
using System.Collections.Generic;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Difficulty"/> data transfer object
    /// </summary>
    public class DifficultyData
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IList<QuestionData> Questions { get; set; }
    }
}
