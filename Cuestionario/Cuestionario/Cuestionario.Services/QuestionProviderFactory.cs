using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services
{
    public class QuestionProviderFactory
    {
        public QuestionProviderFactory() { }
        public IQuestionProvider BuildProvider(QuestionProviderType pType)
        {
            throw new NotImplementedException();
        }
    }
}
