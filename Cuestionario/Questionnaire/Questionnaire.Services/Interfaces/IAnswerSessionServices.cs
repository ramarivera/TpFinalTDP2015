using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface IAnswerSessionServices
    {
        IEnumerable<AnswerSession> GetAll();

        AnswerSession GetById(int pAnswerSessionId);

        AnswerSession StartSession(AnswerSessionStartData pAnswerSessionStartData);

        AnswerSession EndSession(int pAnswerSessionId);
    }
}
