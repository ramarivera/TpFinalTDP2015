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
        Question Create(QuestionDTO pQuestion);
        Question Update(long pQuestionId, QuestionDTO pUpdateQuestion);
        void Delete(long pQuestionId);
    }
}
