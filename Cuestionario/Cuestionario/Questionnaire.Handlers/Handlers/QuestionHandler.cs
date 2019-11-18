using AutoMapper;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Services;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System.Collections.Generic;

namespace Questionnaire.Handlers.Handlers
{
    /// <summary>
    /// Handler class for <see cref="Model.Question"/> related use cases such as: <see cref="HandlerImportQuestionsFromProvider"/> 
    /// and <see cref="GetQuestionsForSession"/>
    /// </summary>
    public class QuestionHandler : BaseHandler, IQuestionHandler
    {
        private readonly IQuestionServices iQuestionService;
        private readonly QuestionProviderFactory iQuestionProviderFactory;

        public QuestionHandler(
            IQuestionServices pQuestionService,
            QuestionProviderFactory pQuestionProviderFactory,
            IMapper pMapper)    
            : base(pMapper)
        {
            this.iQuestionService = pQuestionService;
            this.iQuestionProviderFactory = pQuestionProviderFactory;
        }

        /// <summary>
        /// Imports new <see cref="Model.Question"/> from a specific Question Provider
        /// </summary>
        /// <param name="pType">Question Provider</param>
        [Transactional]
        public void HandlerImportQuestionsFromProvider(QuestionProviderType pType)
        {
            var lProvider = this.iQuestionProviderFactory.BuildProvider(pType);

            var lExistentQuestion = iQuestionService.GetAll();

            var lNewQuestionCandidates = lProvider.FilterNotImportedQuestions(lExistentQuestion);

            foreach (var lNewQuestionCandidate in lNewQuestionCandidates)
            {
                this.iQuestionService.Create(lNewQuestionCandidate);
            }
        }

        /// <summary>
        /// Gets Questions for a specific Answer Session, according to selected options
        /// </summary>
        /// <param name="pAnswerSessionStartData">Answer Session start data</param>
        /// <returns>A list of <see cref="QuestionData"/></returns>
        [Transactional]
        public IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lSessionQuestions = iQuestionService.GetQuestionsForSession(pAnswerSessionStartData);

            var lResult = Mapper.Map<IList<QuestionData>>(lSessionQuestions);
            return lResult;
        }
    }
}
