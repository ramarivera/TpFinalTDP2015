using System.Collections.Generic;

namespace Cuestionario.Services.DTO
{
    public class QuestionCreationData
    {
        public QuestionCreationData()
        {
            Answers = new List<AnswerCreationData>();
        }

        public CategoryData Category { get; set; }

        public DifficultyData Difficulty { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public IList<AnswerCreationData> Answers { get; set; }

        public AnswerCreationData CorrectAnswer { get; set; }
    }
}