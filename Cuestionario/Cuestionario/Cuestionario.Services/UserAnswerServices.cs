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
    public class UserAnswerServices : IUserAnswerServices
    {
        private ISession _session;

        private IQuestionServices _questionServices;

        private IAnswerSessionServices _answerSessionServices;

        private IAnswerServices _answerServices;

        public UserAnswerServices(
            ISession session,
            IQuestionServices questionServices,
            IAnswerSessionServices answerSessionServices,
            IAnswerServices answerServices)
        {
            _session = session;
            _questionServices = questionServices;
            _answerSessionServices = answerSessionServices;
            _answerServices = answerServices;
        }
        public UserAnswer Create(UserAnswerDTO pUserAnswer)
        {
            var lQuestion = _questionServices.GetById(pUserAnswer.Question.Id);

            var lAnswerSession = _answerSessionServices.GetById(pUserAnswer.AnswerSession.Id);

            var lChosenAnswer = _answerServices.GetById(pUserAnswer.ChosenAnswer.Id);

            UserAnswer lUserAnswer = new UserAnswer
            {
                AnswerStatus = pUserAnswer.AnswerStatus,
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

        public UserAnswer Update(long pId, UserAnswerDTO pUpdateUserAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
