using Cuestionario.Services.Interfaces;
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
        private readonly QuestionProviderFactory iQuestionProviderFactory;

        // No se que tan bien esta que el service y el provider se usen en el mismo metodo btw.

        public QuestionHandler(
            IQuestionServices pQuestionService,
            ICategoryServices pCategoryService,
            QuestionProviderFactory pQuestionProviderFactory,
            IMapper pMapper)    
            : base(pMapper)
        {
            this.iQuestionService = pQuestionService;
            this.iCategoryService = pCategoryService;
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
        //aca sería correcto llevar todas las preguntas que cumplan con las condiciones? o solo el número indicado? como se pueden obtener al azar?
        public IEnumerable<QuestionData> GetQuestionsForSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lQuestions = iQuestionService.GetAll()
                .Where(x => x.Category == iCategoryService.GetById(pAnswerSessionStartData.CategoryId));

            var lResult = Mapper.Map<IList<QuestionData>>(lQuestions);
            return lResult;
        }
    }
}
