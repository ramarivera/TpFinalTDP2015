using Questionnaire.Model;

namespace Questionnaire.Services.DTO
{
    /// <summary>
    /// Represents <see cref="Answer"/> data transfer object
    /// </summary>
    public class AnswerData
    {
        public int Id { get; set; }
        public QuestionData Question { get; set; }
        public string Description { get; set; }
        public bool Correct { get; set; }
    }
}
