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
        private ISession iSession;

        private ICategoryServices iCategoryServices;

        private IDifficultyServices iDifficultyServices;

        public QuestionServices(
            ISession session,
            ICategoryServices categoryServices,
            IDifficultyServices difficcultyServices)
        {
            iSession = session;
            iCategoryServices = categoryServices;
            iDifficultyServices = difficcultyServices;
        }

        public Question Create(QuestionCreationData pQuestionData)
        {
            var lCategory = iCategoryServices.GetById(pQuestionData.Category.Id);
            if (lCategory == null)
            {
                lCategory = iCategoryServices.Create(pQuestionData.Category);
            }

            var lDifficulty = iDifficultyServices.GetById(pQuestionData.Difficulty.Id);

            Question lQuestion = new Question
            {
                Description = pQuestionData.Description,
                Category = lCategory,
                Difficulty = lDifficulty
            };

            Answer lAnswer = new Answer();

            foreach (var lAnswerData in pQuestionData.Answers)
            {
                lAnswer = CreateAnswer(lAnswerData);
                lQuestion.AddAnswer(lAnswer);
            }
            
            iSession.Save(lQuestion);
            iSession.Transaction.Commit();

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetAll()
        {
            IQueryable<Question> lQuestions =
                iSession.Query<Question>();

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
            var lAnswer = iSession.Query<Answer>()
                .FirstOrDefault(x => x.Id == pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {lAnswer} was not found");
            }

            return lAnswer;
        }
    }
}
