using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IQuestionServices
    {
        IEnumerable<Question> GetAll();

        Question GetById(int pQuestionId);

        Question Create(QuestionCreationData pQuestionData);

        Answer GetAnswerById(int pAnswerId);

        IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
