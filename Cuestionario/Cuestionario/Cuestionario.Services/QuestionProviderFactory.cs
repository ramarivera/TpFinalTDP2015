using Questionnaire.Services.Interfaces;
using Questionnaire.Services.DependencyInjection;

namespace Questionnaire.Services
{
    // TODO missing documentation
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
