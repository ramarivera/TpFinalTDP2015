using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.Interfaces
{
    public interface IAnswerSessionServices
    {
        IQueryable<AnswerSession> GetAll();

        AnswerSession GetById(long pAnswerSessionId);

        AnswerSession StartSession(AnswerSessionStartData pAnswerSessionStartData);

        AnswerSession EndSession(long pAnswerSessionId);

        AnswerSession Update(long pAnswerSessionId, AnswerSessionData pUpdateAnswerSession);

        void Delete(long pAnswerSessionId);
    }
}
