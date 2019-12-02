using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.Services
{
    /// <summary>
    /// Contains all business logic related to <see cref="UserAnswer"/> model class
    /// </summary>
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
        /// Creates a new <see cref="UserAnswer"/> that will be stored in the database
        /// </summary>
        /// <param name="pUserAnswerData"> <see cref="UserAnswer"/> data</param>
        /// <param name="pAnswerSession"><see cref="AnswerSession"/> associated to the new <see cref="UserAnswer"/></param>
        /// <returns>Created <see cref="UserAnswer"/></returns>
        public UserAnswer Create(UserAnswerCreationData pUserAnswerData, AnswerSession pAnswerSession)
        {
            var lQuestion = iQuestionServices.GetById(pUserAnswerData.Question.Id);
            var lChosenAnswer = lQuestion.Answers.FirstOrDefault(x => x.Id == pUserAnswerData.ChosenAnswer.Id);

            var lUserAnswer = new UserAnswer
            {
                Question = lQuestion,
                AnswerSession = pAnswerSession,
                ChosenAnswer = lChosenAnswer
            };

            this.iUserAnswerRepository.Add(lUserAnswer);

            return lUserAnswer;
        }

        /// <summary>
        /// Gets all stored <see cref="UserAnswer"/>
        /// </summary>
        /// <returns>A list of <see cref="UserAnswer"/></returns>
        public IEnumerable<UserAnswer> GetAll()
        {
            return this.iUserAnswerRepository.ToList();
        }

        /// <summary>
        /// Gets a specific <see cref="UserAnswer"/>
        /// </summary>
        /// <param name="pUserAnswerId">Specific <see cref="UserAnswer"/> Id</param>
        /// <returns>A <see cref="UserAnswer"/></returns>
        public UserAnswer GetById(int pUserAnswerId)
        {
            var lUserAnswer = this.iUserAnswerRepository.FindById(pUserAnswerId);

            if (lUserAnswer == null)
            {
                throw new ArgumentException($"UserAnswer with Id {pUserAnswerId} was not found");
            }

            return lUserAnswer;
        }
    }
}
