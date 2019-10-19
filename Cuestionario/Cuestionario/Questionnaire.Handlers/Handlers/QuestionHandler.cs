using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using Cuestionario.Services;

namespace Questionnaire.Handlers.Handlers
{
    public class QuestionHandler : BaseHandler, IQuestionHandler
    {
        private readonly IQuestionServices iQuestionService;
        private readonly QuestionProviderFactory iQuestionProviderFactory;

        // No se que tan bien esta que el service y el provider se usen en el mismo metodo btw.

        public QuestionHandler(
            IQuestionServices pQuestionService,
            QuestionProviderFactory pQuestionProviderFactory)
        {
            this.iQuestionService = pQuestionService;
            this.iQuestionProviderFactory = pQuestionProviderFactory;
        }

        [Transactional]
        public void HandlerImportQuestionsFromProvider(QuestionProviderType pType)
        {
            var lProvider = this.iQuestionProviderFactory.BuildProvider(pType);
            // :)
            var lExistentQuestion = iQuestionService.GetAll();

            var lNewQuestionCandidates = lProvider.FilterNotImportedQuestions(lExistentQuestion);

            foreach (var lNewQuestion in lNewQuestionCandidates)
            {
                iQuestionService.Create(lNewQuestion);
            }
        }
    }
}
