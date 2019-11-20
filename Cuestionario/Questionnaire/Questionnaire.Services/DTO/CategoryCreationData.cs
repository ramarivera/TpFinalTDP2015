using System.Collections.Generic;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Category"/> creation data transfer object
    /// </summary>
    public class CategoryCreationData
    {
        public string Description { get; set; }
        public IList<QuestionData> Questions { get; set; }
    }
}
