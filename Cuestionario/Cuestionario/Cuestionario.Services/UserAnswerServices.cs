using Cuestionario.Model;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;

namespace Cuestionario.Services
{
    public class UserAnswerServices : IUserAnswerServices
    {
        private ISession _session;

        private IQuestionServices _questionServices;

        private IAnswerSessionServices _answerSessionServices;

        public UserAnswerServices(
            ISession session,
            IQuestionServices questionServices,
            IAnswerSessionServices answerSessionServices)
        {
            _session = session;
            _questionServices = questionServices;
            _answerSessionServices = answerSessionServices;
        }
        public UserAnswer Create(UserAnswerCreactionData pUserAnswerData)
        {
            var lQuestion = _questionServices.GetById(pUserAnswerData.Question.Id);

            var lAnswerSession = _answerSessionServices.GetById(pUserAnswerData.AnswerSession.Id);

            var lChosenAnswer = _questionServices.GetAnswerById(pUserAnswerData.ChosenAnswer.Id);

            UserAnswer lUserAnswer = new UserAnswer
            {
                AnswerStatus = pUserAnswerData.AnswerStatus,
                Question = lQuestion,
                AnswerSession = lAnswerSession,
                ChosenAnswer = lChosenAnswer
            };

            _session.Save(lUserAnswer);
            _session.Transaction.Commit();

            return lUserAnswer;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserAnswer> GetAll()
        {
            IQueryable<UserAnswer> lUserAnswers =
                _session.Query<UserAnswer>();

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

        public UserAnswer Update(long pId, UserAnswerCreactionData pUpdateUserAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
