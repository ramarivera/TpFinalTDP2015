using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.Interfaces
{
    public interface IQuestionProvider
    {
        IEnumerable<QuestionCreationData> RetrieveAllQuestions();
        IList<QuestionCreationData> FilterNotImportedQuestions(IEnumerable<Question> pQuestions);
        bool AreQuestionsEqual(Question pQuestion, QuestionCreationData pQuestionData);
    }
}
