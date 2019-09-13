using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.DTO;
using NHibernate;
using Cuestionario.Services.Interfaces;

namespace Cuestionario.Services
{
    public class QuestionServices : IQuestionServices
    {
        private ISession _session;

        private ICategoryServices _categoryServices;

        private IDifficultyServices _difficultyServices;

        public QuestionServices(
            ISession session,
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices)
        {
            _session = session;
            _categoryServices = categoryServices;
            _difficultyServices = difficcultyServices;
        }

        public Question Create(QuestionCreationData pQuestionData)
        {
            //var lCategory = _categoryServices.GetById(pQuestionData.Category.Id);

            //var lDifficulty = _difficultyServices.GetById(pQuestionData.Difficulty.Id);

            var lCategory = _categoryServices.Create(pQuestionData.Category);

            Question lQuestion = new Question
            {
                Description = pQuestionData.Description,
                Category = lCategory,
                //Difficulty = lDifficulty
            };

            Answer lAnswer = new Answer();

            foreach (var lAnswerData in pQuestionData.Answers)
            {
                lAnswer = CreateAnswer(lAnswerData);
                lQuestion.AddAnswer(lAnswer);
            }
            
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
            IQueryable<Question> lQuestions =
                _session.Query<Question>();

            return lQuestions;
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

        public Question Update(long pId, QuestionData pUpdateQuestion)
        {
            throw new NotImplementedException();
        }

        public Answer CreateAnswer(AnswerCreationData pAnswerData)
        {
            //var lQuestion = _questionServices.GetById(pAnswer.Question.Id);

            Answer lAnswer = new Answer
            {
                Description = pAnswerData.Description,
                Correct = pAnswerData.Correct,
                //Question = lQuestion
            };

            //_session.Save(lAnswer);
            //_session.Transaction.Commit();

            return lAnswer;
        }

        public Answer GetAnswerById(long pAnswerId)
        {
            var lAnswer = _session.Query<Answer>()
                .FirstOrDefault(x => x.Id == pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {lAnswer} was not found");
            }

            return lAnswer;
        }
    }
}
