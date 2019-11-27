using Questionnaire.Model.Enums;
using System.Collections.Generic;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Question"/> data transfer object
    /// </summary>
    public class QuestionData
    {
        public int Id { get; set; }
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }
        public QuestionProviderType QuestionProvider { get; set; }
        public IList<AnswerData> Answers { get; set; }
        public AnswerData CorrectAnswer { get; set; }
    }
}