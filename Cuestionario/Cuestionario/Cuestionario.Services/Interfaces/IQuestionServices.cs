using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.Interfaces
{
    public interface IQuestionServices
    {
        IQueryable<Question> GetAll();
        Question GetById(long pQuestionId);
        Question Create(QuestionCreationData pQuestionData);
        Question Update(long pQuestionId, QuestionData pUpdateQuestion);
        void Delete(long pQuestionId);
        Answer GetAnswerById(long pAnswerId);
        IList<Question> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
