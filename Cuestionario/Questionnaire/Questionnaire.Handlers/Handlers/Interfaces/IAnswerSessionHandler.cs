using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IAnswerSessionHandler : IBaseHandler
    {
        int StartAnswerSession(AnswerSessionStartData pSessionStartData);

        int EndAnswerSession(int pId);

        IEnumerable<AnswerSessionData> GetAll();

        AnswerSessionData GetById(int pId);
    }
}
