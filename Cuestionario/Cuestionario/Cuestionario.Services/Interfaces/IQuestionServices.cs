using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Services.Interfaces
{
    public interface IQuestionServices
    {
        IQueryable<Question> GetAll();

        Task<Question> GetByIdAsync(long pQuestionId);

        Task<Question> CreateAsync(QuestionCreationData pQuestionData);

        Question Update(long pQuestionId, QuestionData pUpdateQuestion);

        void Delete(long pQuestionId);

        Task<Answer> GetAnswerByIdAsync(long pAnswerId);

        IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
