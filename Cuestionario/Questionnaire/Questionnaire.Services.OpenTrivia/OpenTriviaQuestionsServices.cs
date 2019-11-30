using Questionnaire.Model.Enums;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Services.OpenTrivia.Models;
using Newtonsoft.Json;
using Questionnaire.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questionnaire.Services.OpenTrivia
{
    /// <summary>
    /// Contains all business logic related to Open Trivia Question Provider
    /// </summary>
    public class OpenTriviaQuestionsServices : IQuestionProvider
    {
        private ICategoryServices iCategoryServices;

        private IDifficultyServices iDifficultyServices;

        HttpClient client = new HttpClient();
        public OpenTriviaQuestionsServices(
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices)
        {
            iCategoryServices = categoryServices;
            iDifficultyServices = difficcultyServices;
        }

        /// <summary>
        /// Retrieve questions from a given URL
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieve the list of all questions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<QuestionCreationData> RetrieveAllQuestions()
        {
            Task<OpenTriviaResponseData> lOperTriviaQuestions = GetQuestionsAsync("https://opentdb.com/api.php?amount=50");

            IList<QuestionCreationData> lQuestions = new List<QuestionCreationData>();

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
                    Source = QuestionSource.OpenTrivia
                };

                //for the correct answer of the question
                AnswerCreationData lAnswerData = new AnswerCreationData
                {
                    Description = WebUtility.HtmlDecode(lOpenTriviaQuestion.CorrectAnswer),
                    Correct = true
                };

                lQuestionData.Answers.Add(lAnswerData);
                lQuestionData.CorrectAnswer = lAnswerData;

                //for the incorrect answers of the question
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

        /// <summary>
        /// Remove from the given set the Questions that were already imported
        /// </summary>
        /// <param name="pQuestions"></param>
        /// <returns></returns>
        public IList<QuestionCreationData> FilterNotImportedQuestions(IEnumerable<Question> pQuestions)
        {
            IEnumerable<QuestionCreationData> lImportedQuestions = this.RetrieveAllQuestions();

            IEnumerable<QuestionCreationData> lNewQuestions = from lImportedQuestion in lImportedQuestions
                                                              where !pQuestions.Any(lQuestion => this.AreQuestionsEqual(lQuestion, lImportedQuestion))
                                                              select lImportedQuestion;

            return lNewQuestions.ToList();
        }

        /// <summary>
        /// Compare two questions
        /// </summary>
        /// <param name="pQuestion"></param>
        /// <param name="pQuestionData"></param>
        /// <returns></returns>
        public bool AreQuestionsEqual(Question pQuestion, QuestionCreationData pQuestionData)
        {
            return (pQuestion.Description == pQuestionData.Description);
        }
    }
}
