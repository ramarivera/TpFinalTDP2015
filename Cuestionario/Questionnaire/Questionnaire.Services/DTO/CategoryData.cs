using System.Collections.Generic;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Category"/> data transfer object
    /// </summary>
    public class CategoryData
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public IList<QuestionData> Questions { get; set; }
    }
}
