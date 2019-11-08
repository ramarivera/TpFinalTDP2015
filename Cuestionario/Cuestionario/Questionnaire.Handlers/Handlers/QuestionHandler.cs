﻿using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using Cuestionario.Services;
using Questionnaire.Model;
using Cuestionario.Services.DTO;
using AutoMapper;

namespace Questionnaire.Handlers.Handlers
{
    public class QuestionHandler : BaseHandler, IQuestionHandler
    {
        private readonly IQuestionServices iQuestionService;
        private readonly ICategoryServices iCategoryService;
        private readonly IDifficultyServices iDifficultyService;
        private readonly QuestionProviderFactory iQuestionProviderFactory;

        // No se que tan bien esta que el service y el provider se usen en el mismo metodo btw.

        public QuestionHandler(
            IQuestionServices pQuestionService,
            ICategoryServices pCategoryService,
            IDifficultyServices pDifficultyServices,
            QuestionProviderFactory pQuestionProviderFactory,
            IMapper pMapper)    
            : base(pMapper)
        {
            this.iQuestionService = pQuestionService;
            this.iCategoryService = pCategoryService;
            this.iDifficultyService = pDifficultyServices;
            this.iQuestionProviderFactory = pQuestionProviderFactory;
        }

        [Transactional]
        public void HandlerImportQuestionsFromProvider(QuestionProviderType pType)
        {
            var lProvider = this.iQuestionProviderFactory.BuildProvider(pType);

            var lExistentQuestion = iQuestionService.GetAll();

            var lNewQuestionCandidates = lProvider.FilterNotImportedQuestions(lExistentQuestion);

            foreach (var lNewQuestion in lNewQuestionCandidates)
            {
                iQuestionService.Create(lNewQuestion);
            }
        }

        [Transactional]
        public IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lSessionQuestions = iQuestionService.GetQuestionsForSession(pAnswerSessionStartData);

            var lResult = Mapper.Map<IList<QuestionData>>(lSessionQuestions);
            return lResult;
        }
    }
}
