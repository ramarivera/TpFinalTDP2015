using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cuestionario.Services.OpenTrivia.Models
{
    public class OpenTriviaQuestionData
    {
        public string Category { get; set; }

        public string Type { get; set; }

        public string Difficulty { get; set; }

        public string Question { get; set; }

        [JsonProperty(PropertyName = "Correct_Answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty(PropertyName = "Incorrect_Answers")]
        public List<string> IncorrectAnswers { get; set; }
    }
}
