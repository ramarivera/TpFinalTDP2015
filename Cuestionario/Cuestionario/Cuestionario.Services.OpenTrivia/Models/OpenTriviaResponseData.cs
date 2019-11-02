using System.Collections.Generic;

namespace Cuestionario.Services.OpenTrivia.Models
{
    public class OpenTriviaResponseData
    {
        public int ResponseCode { get; set; }

        public List<OpenTriviaQuestionData> Results { get; set; }
    }
}
