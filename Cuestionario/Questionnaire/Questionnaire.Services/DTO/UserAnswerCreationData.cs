using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="UserAnswer"/> creation data transfer object
    /// </summary>
    public class UserAnswerCreationData
    {
        public QuestionData Question { get; set; }

        public AnswerSessionData AnswerSession { get; set; }

        public AnswerData ChosenAnswer { get; set; }

        public bool AnswerStatus { get; set; }
    }
}
