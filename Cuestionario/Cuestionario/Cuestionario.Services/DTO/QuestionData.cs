using System.Collections.Generic;

namespace Cuestionario.Services.DTO
{
    public class QuestionData
    {
        public int Id { get; set; }
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IList<AnswerData> Answers { get; set; }
    }
}