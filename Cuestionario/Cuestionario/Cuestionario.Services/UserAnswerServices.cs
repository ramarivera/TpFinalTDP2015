using Questionnaire.Model;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;

namespace Cuestionario.Services
{
    public class UserAnswerServices : IUserAnswerServices
    {
        private ISession iSession;

        private IQuestionServices iQuestionServices;

        public UserAnswerServices(
            ISession pSession,
            IQuestionServices pQuestionServices)
        {
            iSession = pSession;
            iQuestionServices = pQuestionServices;
        }
        public UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession)
        {
            var lQuestion = iQuestionServices.GetById(pUserAnswerData.Question.Id);

            var lChosenAnswer = iQuestionServices.GetAnswerById(pUserAnswerData.ChosenAnswer.Id);

            UserAnswer lUserAnswer = new UserAnswer
            {
                Question = lQuestion,
                AnswerSession = pAnswerSession,
                ChosenAnswer = lChosenAnswer
            };

            iSession.Save(lUserAnswer);

            return lUserAnswer;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserAnswer> GetAll()
        {
            IQueryable<UserAnswer> lUserAnswers =
                iSession.Query<UserAnswer>();

            return lUserAnswers;
        }            

        public UserAnswer GetById(long pUserAnswerId)
        {
            var lUserAnswer = GetAll()
                .FirstOrDefault(x => x.Id == pUserAnswerId);

            if (lUserAnswer == null)
            {
                throw new ArgumentException($"UserAnswer with Id {pUserAnswerId} was not found");
            }

            return lUserAnswer;
        }

        public UserAnswer Update(long pId, UserAnswerData pUpdateUserAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
