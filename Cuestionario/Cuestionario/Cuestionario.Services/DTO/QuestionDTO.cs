using System.Collections.Generic;

namespace Cuestionario.Services.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public string Description { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
    }
}