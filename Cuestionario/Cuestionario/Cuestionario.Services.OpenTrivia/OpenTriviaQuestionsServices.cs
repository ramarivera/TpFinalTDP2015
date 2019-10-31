using Cuestionario.Model;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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

        public async Task<RootObject> GetQuestionsAsync(string pPath)
        {
            RootObject lQuestion = null;
            HttpResponseMessage lResponse = await client.GetAsync(pPath).ConfigureAwait(false);
            if (lResponse.IsSuccessStatusCode)
            {
                lQuestion = await lResponse.Content.ReadAsAsync<RootObject>();
            }

            return lQuestion;
        }

        public IEnumerable<QuestionCreationData> RetrieveAllQuestions()
        {
            //obtiene las preguntas desde Opentdb
            Task<RootObject> lOperTriviaQuestions = GetQuestionsAsync("https://opentdb.com/api.php?amount=50");

            IList<QuestionCreationData> lQuestions = new List<QuestionCreationData>();

            //para cada pregunta obtenida
            foreach (var lOpenTriviaQuestion in lOperTriviaQuestions.Result.Results)
            {
                var lCategoryData = iCategoryServices.RetrieveByDescription(lOpenTriviaQuestion.Category);

                var lDifficultyData = iDifficultyServices.RetrieveByDescription(lOpenTriviaQuestion.Difficulty);

                QuestionCreationData lQuestionData = new QuestionCreationData
                {
                    Description = lOpenTriviaQuestion.Question,
                    Category = lCategoryData,
                    Difficulty = lDifficultyData,
                    Type = lOpenTriviaQuestion.Type,
                };

                //para la respuesta correcta de la pregunta
                AnswerCreationData lAnswerData = new AnswerCreationData
                {
                    Description = lOpenTriviaQuestion.Correct_Answer,
                    //Question = lQuestionDTO
                    Correct = true
                };

                lQuestionData.Answers.Add(lAnswerData);

                //para cada respuesta incorrecta de la pregunta
                foreach (var lOpenTriviaAnswer in lOpenTriviaQuestion.Incorrect_Answers)
                {
                    lAnswerData = new AnswerCreationData
                    {
                        Description = lOpenTriviaAnswer,
                        //Question = lQuestionDTO
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
