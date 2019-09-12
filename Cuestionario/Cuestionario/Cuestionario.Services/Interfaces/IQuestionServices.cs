using Cuestionario.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface IQuestionServices
    {
        IQueryable<Question> GetAll();
        Question GetById(long pQuestionId);
        Question Create(QuestionCreationData pQuestionData);
        Question Update(long pQuestionId, QuestionData pUpdateQuestion);
        void Delete(long pQuestionId);
        Answer CreateAnswer(AnswerCreationData pAnswerData);
        Answer GetAnswerById(long pAnswerId);
    }
}
