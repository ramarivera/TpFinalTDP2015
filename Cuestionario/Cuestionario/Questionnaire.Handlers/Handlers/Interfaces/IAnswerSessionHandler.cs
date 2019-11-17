using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IAnswerSessionHandler : IBaseHandler
    {
        long StartAnswerSession(AnswerSessionStartData pSessionStartData);

        long EndAnswerSession(long pId);

        IEnumerable<AnswerSessionData> GetAll();

        AnswerSessionData GetById(long pId);

        //int StartAnswerSession2();
    }
}
