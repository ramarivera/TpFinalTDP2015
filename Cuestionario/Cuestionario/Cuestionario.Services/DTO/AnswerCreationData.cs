using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Answer"/> creation data transfer object
    /// </summary>
    public class AnswerCreationData
    {
        public QuestionData Question { get; set; }
        public string Description { get; set; }
        public bool Correct { get; set; }
    }
}
