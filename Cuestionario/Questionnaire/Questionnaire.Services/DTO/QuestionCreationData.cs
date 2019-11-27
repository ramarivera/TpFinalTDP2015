using Questionnaire.Model.Enums;
using System.Collections.Generic;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Question"/> creation data transfer object
    /// </summary>
    public class QuestionCreationData
    {
        public QuestionCreationData()
        {
            Answers = new List<AnswerCreationData>();
        }

        public CategoryData Category { get; set; }

        public DifficultyData Difficulty { get; set; }

        public string Description { get; set; }

        public QuestionType QuestionType { get; set; }

        public QuestionSource Source { get; set; }

        public IList<AnswerCreationData> Answers { get; set; }

        public AnswerCreationData CorrectAnswer { get; set; }
    }
}