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
        private ICategoryServices _categoryServices;

        private IDifficultyServices _difficultyServices;

        private IQuestionServices _questionServices;

        HttpClient client = new HttpClient();
        public OpenTriviaQuestionsServices(
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices,
            IQuestionServices questionServices)
        {
            _categoryServices = categoryServices;
            _difficultyServices = difficcultyServices;
            _questionServices = questionServices;
        }

        public async Task<RootObject> GetQuestionsAsync(string pPath)
        {
            RootObject question = null;
            HttpResponseMessage response = await client.GetAsync(pPath);
            if (response.IsSuccessStatusCode)
            {
                question = await response.Content.ReadAsAsync<RootObject>();
            }

            return question;
        }

        public IEnumerable<QuestionCreationData> RetrieveAllQuestions()
        {
            //obtiene las preguntas desde Opentdb
            Task<RootObject> lOperTriviaQuestions = GetQuestionsAsync("https://opentdb.com/api.php?amount=50");

            IList<QuestionCreationData> lQuestions = new List<QuestionCreationData>();

            //para cada pregunta obtenida
            foreach (var lOpenTriviaQuestion in lOperTriviaQuestions.Result.Results)
            {
                var lCategoryData = _categoryServices.RetrieveByDescription(lOpenTriviaQuestion.Category);

                var lDifficultyData = _difficultyServices.RetrieveByDescription(lOpenTriviaQuestion.Difficulty);

                QuestionCreationData lQuestionData = new QuestionCreationData
                {
                    Description = lOpenTriviaQuestion.Question,
                    Category = lCategoryData,
                    Difficulty = lDifficultyData,
                };

                //para la respuesta correcta de la pregunta
                AnswerCreationData lAnswerData = new AnswerCreationData
                {
                    Description = lOpenTriviaQuestion.Correct_Answer,
                    //Question = lQuestionDTO
                };

                lQuestionData.Answers.Add(lAnswerData);

                //para cada respuesta incorrecta de la pregunta
                foreach (var lOpenTriviaAnswer in lOpenTriviaQuestion.Incorrect_Answers)
                {
                    lAnswerData = new AnswerCreationData
                    {
                        Description = lOpenTriviaAnswer//,
                        //Question = lQuestionDTO
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
