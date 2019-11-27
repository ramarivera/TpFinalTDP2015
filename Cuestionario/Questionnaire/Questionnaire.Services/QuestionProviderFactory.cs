using Questionnaire.Services.Interfaces;
using Questionnaire.Services.DependencyInjection;
using Questionnaire.Model.Enums;

namespace Questionnaire.Services
{
    public class QuestionProviderFactory
    {
        private readonly IContainer iContainer;

        public QuestionProviderFactory(IContainer pContainer)
        {
            this.iContainer = pContainer;
        }

        public IQuestionProvider BuildProvider(QuestionProviderType pType)
        {
            return this.iContainer.Resolve<IQuestionProvider>(pType.ToString().ToUpper());
        }
    }
}
