using System.Collections.Generic;

namespace Questionnaire.Services.OpenTrivia.Models
{
    public class OpenTriviaResponseData
    {
        public int ResponseCode { get; set; }

        public List<OpenTriviaQuestionData> Results { get; set; }
    }
}
