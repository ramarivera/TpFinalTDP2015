using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using Questionnaire.Persistence.Repository;
using System.Collections.Generic;

namespace Questionnaire.Services
{
    public class UserAnswerServices : IUserAnswerServices
    {
        private readonly IRepository<UserAnswer> iUserAnswerRepository;
        private readonly IQuestionServices iQuestionServices;

        public UserAnswerServices(
            IRepository<UserAnswer> pUserAnswerRepository,
            IQuestionServices pQuestionServices)
        {
            this.iUserAnswerRepository = pUserAnswerRepository;
            this.iQuestionServices = pQuestionServices;
        }

        /// <summary>
        /// Persist a User Answer in the database
        /// </summary>
        /// <param name="pUserAnswerData"></param>
        /// <param name="pAnswerSession"></param>
        /// <returns></returns>
        public UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession)
        {
            // TODO RAR should we provide a get Ans by Id method, since Ans is "part" of the Q aggregate root?

            var lQuestion = iQuestionServices.GetById(pUserAnswerData.Question.Id);
            var lChosenAnswer = iQuestionServices.GetAnswerById(pUserAnswerData.ChosenAnswer.Id);

            var lUserAnswer = new UserAnswer
            {
                Question = lQuestion,
                AnswerSession = pAnswerSession,
                ChosenAnswer = lChosenAnswer
            };

            this.iUserAnswerRepository.Add(lUserAnswer);

            return lUserAnswer;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAnswer> GetAll()
        {
            return this.iUserAnswerRepository.GetAll();
        }            

        public UserAnswer GetById(long pUserAnswerId)
        {
            var lUserAnswer = this.iUserAnswerRepository.GetById(pUserAnswerId);

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
