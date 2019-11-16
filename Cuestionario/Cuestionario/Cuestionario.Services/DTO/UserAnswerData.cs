using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="UserAnswer"/> data transfer object
    /// </summary>
    public class UserAnswerData
    {
        public int Id { get; set; }
        public QuestionData Question { get; set; }
        public AnswerSessionData AnswerSession { get; set; }
        public AnswerData ChosenAnswer { get; set; }
    }
}
