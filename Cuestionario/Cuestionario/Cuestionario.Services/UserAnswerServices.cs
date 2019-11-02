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

        private IAnswerSessionServices iAnswerSessionServices;

        public UserAnswerServices(
            ISession pSession,
            IQuestionServices pQuestionServices,
            IAnswerSessionServices pAnswerSessionServices)
        {
            iSession = pSession;
            iQuestionServices = pQuestionServices;
            iAnswerSessionServices = pAnswerSessionServices;
        }
        public UserAnswer Create(UserAnswerCreationData pUserAnswerData)
        {
            var lQuestion = iQuestionServices.GetById(pUserAnswerData.Question.Id);

            var lAnswerSession = iAnswerSessionServices.GetById(pUserAnswerData.AnswerSession.Id);

            var lChosenAnswer = iQuestionServices.GetAnswerById(pUserAnswerData.ChosenAnswer.Id);

            UserAnswer lUserAnswer = new UserAnswer
            {
                //AnswerStatus = pUserAnswerData.AnswerStatus,
                Question = lQuestion,
                AnswerSession = lAnswerSession,
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
