using Questionnaire.Model;
using Questionnaire.Model.Enums;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="AnswerSession"/> initial data transfer object
    /// </summary>
    public class AnswerSessionStartData
    {
        public long CategoryId { get; set; }

        public long DifficultyId { get; set; }

        public QuestionSource QuestionSource { get; set; }

        public string Username { get; set; }

        public int QuestionsCount { get; set; }

    }
}
