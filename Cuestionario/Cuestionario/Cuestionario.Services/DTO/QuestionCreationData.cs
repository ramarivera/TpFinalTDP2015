using System.Collections.Generic;

namespace Cuestionario.Services.DTO
{
    public class QuestionCreationData
    {
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Description { get; set; }
        public IList<AnswerCreationData> Answers { get; set; }
    }
}