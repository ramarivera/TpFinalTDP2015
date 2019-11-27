using Questionnaire.Model.Enums;
using Questionnaire.Services;
using Questionnaire.Services.DTO;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IQuestionHandler : IBaseHandler
    {
        void HandlerImportQuestionsFromProvider(QuestionSource pType);

        IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
