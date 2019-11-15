using Questionnaire.Model;
using Questionnaire.Services;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Handlers.Handlers.Interfaces
{
    public interface IQuestionHandler : IBaseHandler
    {
        Task HandlerImportQuestionsFromProviderAsync(QuestionProviderType pType);

        IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData);
    }
}
