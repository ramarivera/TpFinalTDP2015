using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IAnswerSessionServices
    {
        IEnumerable<AnswerSession> GetAll();

        AnswerSession GetById(long pAnswerSessionId);

        AnswerSession StartSession(AnswerSessionStartData pAnswerSessionStartData);

        AnswerSession EndSession(long pAnswerSessionId);

        AnswerSession Update(long pAnswerSessionId, AnswerSessionData pUpdateAnswerSession);

        void Delete(long pAnswerSessionId);
    }
}
