using Cuestionario.Model.Enums;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using Cuestionario.Services.OpenTrivia.Models;
using Newtonsoft.Json;
using Questionnaire.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cuestionario.Services.OpenTrivia
{
    public class OpenTriviaQuestionsServices : IQuestionProvider
    {
        private ICategoryServices iCategoryServices;

        private IDifficultyServices iDifficultyServices;

        private IQuestionServices iQuestionServices;

        HttpClient client = new HttpClient();
        public OpenTriviaQuestionsServices(
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices,
            IQuestionServices questionServices)
        {
            iCategoryServices = categoryServices;
            iDifficultyServices = difficcultyServices;
            iQuestionServices = questionServices;
        }

        public async Task<OpenTriviaResponseData> GetQuestionsAsync(string pPath)
        {
            OpenTriviaResponseData lQuestions = null;
            HttpResponseMessage lResponse = await client.GetAsync(pPath).ConfigureAwait(false);

            if (lResponse.IsSuccessStatusCode)
            {
                var lStringResponse = await lResponse.Content.ReadAsStringAsync();
                lQuestions = JsonConvert.DeserializeObject<OpenTriviaResponseData>(lStringResponse);
            }

            return lQuestions;
        }

        public IEnumerable<QuestionCreationData> RetrieveAllQuestions()
        {
            //obtiene las preguntas desde Opentdb
            Task<OpenTriviaResponseData> lOperTriviaQuestions = GetQuestionsAsync("https://opentdb.com/api.php?amount=50");

            IList<QuestionCreationData> lQuestions = new List<QuestionCreationData>();

            //para cada pregunta obtenida
            foreach (var lOpenTriviaQuestion in lOperTriviaQuestions.Result.Results)
            {
                var lCategoryData = iCategoryServices.RetrieveByDescription(lOpenTriviaQuestion.Category);

                var lDifficultyData = iDifficultyServices.RetrieveByDescription(lOpenTriviaQuestion.Difficulty);

                QuestionType lQuestionType = new QuestionType();

                if (lOpenTriviaQuestion.Type == "boolean")
                {
                    lQuestionType = QuestionType.YesNo;
                }
                else if (lOpenTriviaQuestion.Type == "multiple")
                {
                    lQuestionType = QuestionType.MultipleChoice;
                }

                QuestionCreationData lQuestionData = new QuestionCreationData
                {
                    Description = WebUtility.HtmlDecode(lOpenTriviaQuestion.Question),
                    Category = lCategoryData,
                    Difficulty = lDifficultyData,
                    QuestionType = lQuestionType,
                };

                //para la respuesta correcta de la pregunta
                AnswerCreationData lAnswerData = new AnswerCreationData
                {
                    Description = WebUtility.HtmlDecode(lOpenTriviaQuestion.CorrectAnswer),
                    Correct = true
                };

                lQuestionData.Answers.Add(lAnswerData);
                lQuestionData.CorrectAnswer = lAnswerData;

                //para cada respuesta incorrecta de la pregunta
                foreach (var lOpenTriviaAnswer in lOpenTriviaQuestion.IncorrectAnswers)
                {
                    lAnswerData = new AnswerCreationData
                    {
                        Description = WebUtility.HtmlDecode(lOpenTriviaAnswer),
                        Correct = false
                    };

                    lQuestionData.Answers.Add(lAnswerData);
                }

                lQuestions.Add(lQuestionData);
            }

            return lQuestions.AsEnumerable();
        }

        public IEnumerable<QuestionCreationData> FilterNotImportedQuestions(IEnumerable<Question> pQuestions)
        {
            IEnumerable<QuestionCreationData> lImportedQuestions = this.RetrieveAllQuestions();

            IEnumerable<QuestionCreationData> lNewQuestions = from lImportedQuestion in lImportedQuestions
                                                              where !pQuestions.Any(lQuestion => this.AreQuestionsEqual(lQuestion, lImportedQuestion))
                                                              select lImportedQuestion;

            return lNewQuestions;
        }

        public bool AreQuestionsEqual(Question pQuestion, QuestionCreationData pQuestionData)
        {
            return (pQuestion.Description == pQuestionData.Description);
        }
    }
}
