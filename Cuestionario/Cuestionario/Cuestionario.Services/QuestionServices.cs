using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.DTO;
using NHibernate;
using Cuestionario.Services.Interfaces;
using Cuestionario.Services.OpenTrivia;

namespace Cuestionario.Services
{
    public class QuestionServices : IQuestionServices
    {
        private ISession _session;

        private ICategoryServices _categoryServices;

        private IDifficultyServices _difficultyServices;

        private IAnswerServices _answerServices;

        private OpenTriviaQuestionsServices _opentdbQuestionsServices;

        public QuestionServices(
            ISession session,
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices,
            IAnswerServices answerServices,
            OpenTriviaQuestionsServices opentdbQuestionsServices)
        {
            _session = session;
            _categoryServices = categoryServices;
            _difficultyServices = difficcultyServices;
            _answerServices = answerServices;
            _opentdbQuestionsServices = opentdbQuestionsServices;
        }

        public Question Create(QuestionDTO pQuestion)
        {
            var lCategory = _categoryServices.GetById(pQuestion.Category.Id);

            var lDifficulty = _difficultyServices.GetById(pQuestion.Difficulty.Id);

            Question lQuestion = new Question
            {
                Description = pQuestion.Description,
                Category = lCategory,
                Difficulty = lDifficulty
            };

            //faltaría agregar las respuestas relacionadas

            _session.Save(lQuestion);
            _session.Transaction.Commit();

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetAll()
        {
            IQueryable<Question> lDifficulties =
                _session.Query<Question>();

            return lDifficulties;
        }         

        public Question GetById(long pQuestionId)
        {
            var lQuestion = GetAll()
                .FirstOrDefault(x => x.Id == pQuestionId);

            if (lQuestion == null)
            {
                throw new ArgumentException($"Question with Id {pQuestionId} was not found");
            }

            return lQuestion;
        }

        public Question Update(long pId, QuestionDTO pUpdateQuestion)
        {
            throw new NotImplementedException();
        }

        public void GetModelQuestions(string pPath)
        {
            //obtiene las preguntas desde Opentdb
            Task<RootObject> lOperTriviaQuestions = _opentdbQuestionsServices.GetQuestionsAsync(pPath);

            //para cada pregunta obtenida
            foreach (var lOpenTriviaQuestion in lOperTriviaQuestions.Result.Results)
            {
                var lCategory = _categoryServices.GetByDescription(lOpenTriviaQuestion.Category);

                var lDifficulty = _difficultyServices.GetByDescription(lOpenTriviaQuestion.Difficulty);

                QuestionDTO lQuestionDTO = new QuestionDTO
                {
                    Description = lOpenTriviaQuestion.Question,
                    //Category = lCategory,
                    //Difficulty = lDifficulty,
                };

                var lQuestion = Create(lQuestionDTO);

                //para la repsuesta correcta de la pregunta
                AnswerDTO lAnswerDTO = new AnswerDTO
                {
                    Description = lOpenTriviaQuestion.Correct_Answer,
                    Question = lQuestionDTO
                };

                var lAnswer = _answerServices.Create(lAnswerDTO);

                //para cada respuesta incorrecta de la pregunta
                foreach (var lOpenTriviaAnswer in lOpenTriviaQuestion.Incorrect_Answers)
                {
                    lAnswerDTO = new AnswerDTO
                    {
                        Description = lOpenTriviaAnswer,
                        Question = lQuestionDTO
                    };

                    lAnswer = _answerServices.Create(lAnswerDTO);
                }
            }
        }
    }
}
