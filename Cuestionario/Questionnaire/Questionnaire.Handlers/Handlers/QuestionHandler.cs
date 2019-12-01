using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.DTO;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Services;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
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
            ILogger pLogger,
            IMapper pMapper)    
            : base(pMapper, pLogger)
        {
            this.iQuestionService = pQuestionService;
            this.iQuestionProviderFactory = pQuestionProviderFactory;
        }

        /// <summary>
        /// Imports new <see cref="Model.Question"/> from a specific Question Provider
        /// </summary>
        /// <param name="pSource">Question Provider</param>
        [Transactional]
        public void HandlerImportQuestionsFromProvider(QuestionImportingRequestData pRequestData, Action<decimal> pOnProgressCallback)
        {
            var lSource = pRequestData.Source;
            var lAmount = pRequestData.Amount;

            this.Logger.LogInformation("Request received for {lSource} for {lAmount} questions", lSource, lAmount);

            var lProvider = this.iQuestionProviderFactory.BuildProvider(lSource);
            var lCurrentIndex = 0;

            // TODO review this
            while(lCurrentIndex < lAmount)
            {
                var lExistentQuestion = iQuestionService.GetAll();

                var lNewQuestionCandidates = lProvider.FilterNotImportedQuestions(lExistentQuestion);

                for (int i = 0; i < lNewQuestionCandidates.Count; i++)
                {
                    var lCurrentQuestion = lNewQuestionCandidates[i];
                    if (lCurrentIndex < lAmount)
                    {
                        this.iQuestionService.Create(lCurrentQuestion);
                        lCurrentIndex++;
                        pOnProgressCallback(((decimal)lCurrentIndex / (decimal)lAmount)*100);
                        this.Logger.LogDebug("Created question number {lCurrentIndex} out of {lAmount}", lCurrentIndex, lAmount, lCurrentQuestion);
                    }
                }
            }

            pOnProgressCallback(100m);
            this.Logger.LogInformation("Request finished for {lSource} for {lAmount} questions", lSource, lAmount);
        }

        /// <summary>
        /// Gets Questions for a specific Answer Session, according to selected options
        /// </summary>
        /// <param name="pAnswerSessionStartData">Answer Session start data</param>
        /// <returns>A list of <see cref="QuestionData"/></returns>
        [Transactional]
        public IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            this.Logger.LogInformation("Request received for {QuestionsCount} {QuestionSource} questions for a new AnswerSession", pAnswerSessionStartData.QuestionsCount, pAnswerSessionStartData.QuestionSource);
           
            var lSessionQuestions = iQuestionService.GetQuestionsForSession(pAnswerSessionStartData);

            var lResult = Mapper.Map<IList<QuestionData>>(lSessionQuestions);
            this.Logger.LogInformation("Request finished for {QuestionsCount} {QuestionSource} questions for a new AnswerSession", pAnswerSessionStartData.QuestionsCount, pAnswerSessionStartData.QuestionSource);
            return lResult;
        }
    }
}
