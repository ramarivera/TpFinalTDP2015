using Cuestionario.Model.Enums;
using System.Collections.Generic;

namespace Cuestionario.Services.DTO
{
    public class QuestionData
    {
        public int Id { get; set; }
        public CategoryData Category { get; set; }
        public DifficultyData Difficulty { get; set; }
        public string Description { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<AnswerData> Answers { get; set; }
        public AnswerData CorrectAnswer { get; set; }
    }
}