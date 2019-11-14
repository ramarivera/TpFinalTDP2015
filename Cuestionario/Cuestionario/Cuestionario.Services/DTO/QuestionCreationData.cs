using Cuestionario.Model.Enums;
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

        public QuestionType QuestionType { get; set; }// TODO ver esto

        public IList<AnswerCreationData> Answers { get; set; }

        public AnswerCreationData CorrectAnswer { get; set; }
    }
}