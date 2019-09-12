using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services
{
    public class QuestionHandler
    {
        private IQuestionServices _questionService;
        void HandlerImportQuestionsFromProvider(QuestionProviderType pType)
        {
            var lFactory = new QuestionProviderFactory();
            var lProvider = lFactory.BuildProvider(pType);
            var lExistentQuestion = _questionService.GetAll();

            var lNewQuestionCandidates = lProvider.FilterNotImportedQuestions(lExistentQuestion);

            foreach (var lNewQuestion in lNewQuestionCandidates)
            {
                _questionService.Create(lNewQuestion);
            }
        }
    }
}
