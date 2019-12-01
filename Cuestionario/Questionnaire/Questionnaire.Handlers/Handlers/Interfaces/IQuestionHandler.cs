using Questionnaire.Handlers.DTO;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IQuestionHandler : IBaseHandler
    {
        void HandlerImportQuestionsFromProvider(QuestionImportingRequestData pRequestData, Action<decimal> pOnProgressCallback);

        IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
