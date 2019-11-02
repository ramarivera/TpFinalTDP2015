using Questionnaire.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface IQuestionProvider
    {
        IEnumerable<QuestionCreationData> RetrieveAllQuestions();
        IEnumerable<QuestionCreationData> FilterNotImportedQuestions(IEnumerable<Question> pQuestions);
        bool AreQuestionsEqual(Question pQuestion, QuestionCreationData pQuestionData);
    }
}
