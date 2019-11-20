using System.Collections.Generic;

namespace Questionnaire.Services.OpenTrivia.Models
{
    /// <summary>
    /// Represents an OpenTrivia (http://opentdb.com) API response
    /// </summary>
    public class OpenTriviaResponseData
    {
        public int ResponseCode { get; set; }

        public List<OpenTriviaQuestionData> Results { get; set; }
    }
}
