using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Services
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

        public async Task<UserAnswer> CreateAsync(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession)
        {
            // TODO RAR should we provide a get Ans by Id method, since Ans is "part" of the Q aggregate root?

            var lQuestion = await iQuestionServices.GetByIdAsync(pUserAnswerData.Question.Id);
            var lChosenAnswer = await iQuestionServices.GetAnswerByIdAsync(pUserAnswerData.ChosenAnswer.Id);

            var lUserAnswer = new UserAnswer
            {
                Question = lQuestion,
                AnswerSession = pAnswerSession,
                ChosenAnswer = lChosenAnswer
            };

            await iSession.SaveAsync(lUserAnswer);

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
