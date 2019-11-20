using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Linq;
using Questionnaire.Persistence.Repository;
using System.Collections.Generic;

namespace Questionnaire.Services
{
    /// <summary>
    /// Contains all business logic related to <see cref="AnswerSession"/> model class
    /// </summary>
    public class AnswerSessionServices : IAnswerSessionServices
    {
        private readonly IRepository<AnswerSession> iAnswerSessionRepository;
        private readonly ICategoryServices iCategoryServices;
        private readonly IDifficultyServices iDifficultyServices;
        private readonly IUserAnswerServices iUserAnswerServices;

        public AnswerSessionServices(
            IRepository<AnswerSession> pAnswerSessionRepository,
            ICategoryServices pCategoryServices,
            IDifficultyServices pDificcultyServices,
            IUserAnswerServices pUserAnswerServces)
        {
            this.iAnswerSessionRepository = pAnswerSessionRepository;
            this.iCategoryServices = pCategoryServices;
            this.iDifficultyServices = pDificcultyServices;
            this.iUserAnswerServices = pUserAnswerServces;
        }

        /// <summary>
        /// Initializes an <see cref="AnswerSession"/>, that will be stored in the database
        /// </summary>
        /// <param name="pAnswerSessionStartData"> <see cref="AnswerSession"/> inicial data</param>
        /// <returns>Created <see cref="AnswerSession"/></returns>
        public AnswerSession StartSession(AnswerSessionStartData pAnswerSessionStartData)
        {
            var lCategory = this.iCategoryServices.GetById(pAnswerSessionStartData.CategoryId);

            var lDifficulty = this.iDifficultyServices.GetById(pAnswerSessionStartData.DifficultyId);

            AnswerSession lAnswerSession = new AnswerSession
            {
                Username = pAnswerSessionStartData.Username,
                StartTime = DateTime.Now,
                EndTime = null,
                Category = lCategory,
                Difficulty = lDifficulty
            };

            this.iAnswerSessionRepository.Add(lAnswerSession);

            return lAnswerSession;
        }

        /// <summary>
        /// Finalizes an <see cref="AnswerSession"/>, updating it in the database
        /// </summary>
        /// <param name="pAnswerSessionId"></param>
        /// <returns>The <see cref="AnswerSession"/> with all its attributes completed</returns>
        public AnswerSession EndSession(long pAnswerSessionId)
        {
            var lAnswerSession = this.GetById(pAnswerSessionId);

            lAnswerSession.EndTime = DateTime.Now;
            int lDifficultyFactor = iDifficultyServices.GetDifficultyFactor(lAnswerSession.Difficulty.Description);
            int lTimeFactor = this.GetTimeFactor(lAnswerSession);

            lAnswerSession.Score = this.GetSessionScore(pAnswerSessionId, lDifficultyFactor, lTimeFactor);

            this.iAnswerSessionRepository.Update(lAnswerSession);

            return lAnswerSession;
        }

        /// <summary>
        /// Calculates the score of an <see cref="AnswerSession"/>
        /// </summary>
        /// <param name="pAnswerSessionId">Specific <see cref="AnswerSession"/> Id</param>
        /// <param name="pDifficultyFactor"><see cref="AnswerSession"/> associated difficulty factor</param>
        /// <param name="pTimeFactor"><see cref="AnswerSession"/> associated time factor</param>
        /// <returns><see cref="AnswerSession"/> score</returns>
        private double GetSessionScore(long pAnswerSessionId, int pDifficultyFactor, int pTimeFactor)
        {
            var lUserAnswers = iUserAnswerServices.GetAll().Where(x => x.AnswerSession.Id == pAnswerSessionId);

            int lCorrectAnswersCount = 0;

            foreach (var lUserAnswer in lUserAnswers)
            {
                if (lUserAnswer.IsAnswerCorrect)
                {
                    lCorrectAnswersCount++;
                }
            }

            double lScore = ((double)lCorrectAnswersCount / (double)lUserAnswers.Count()) * pDifficultyFactor * pTimeFactor;

            return lScore;
        }

        /// <summary>
        /// Calculates the score per answer based on the total duration and amount of questions of the given <see cref="AnswerSession"/>
        /// </summary>
        /// <param name="pAnswerSession">Specific <see cref="AnswerSession"/></param>
        /// <returns><see cref="AnswerSession"/> time factor</returns>
        private int GetTimeFactor(AnswerSession pAnswerSession)
        {
            double lSessionDuration = (pAnswerSession.EndTime - pAnswerSession.StartTime).Value.TotalSeconds;
            int lTimeFactor = 0;
            double lTimePerQuestion = (pAnswerSession.Answers.Count() / lSessionDuration);

            if (lTimePerQuestion < 5) { lTimeFactor = 5; }
            else if (lTimePerQuestion >= 5 && lTimePerQuestion <= 20) { lTimeFactor = 5; }
            else if (lTimePerQuestion > 20) { lTimeFactor = 1; }

            return lTimeFactor;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all stored <see cref="AnswerSession"/>
        /// </summary>
        /// <returns>A list of <see cref="AnswerSession"/></returns>
        public IEnumerable<AnswerSession> GetAll()
        {
            return this.iAnswerSessionRepository.GetAll();
        }

        /// <summary>
        /// Gets a specific <see cref="AnswerSession"/>
        /// </summary>
        /// <param name="pAnswerSessionId">Specific <see cref="AnswerSession"/> Id</param>
        /// <returns>A <see cref="AnswerSession"/></returns>
        public AnswerSession GetById(long pAnswerSessionId)
        {
            var lAnswerSession = this.iAnswerSessionRepository.GetById(pAnswerSessionId);

            if (lAnswerSession == null)
            {
                throw new ArgumentException($"AnswerSession with Id {pAnswerSessionId} was not found");
            }

            return lAnswerSession;
        }

        public AnswerSession Update(long pId, AnswerSessionData pUpdateAnswerSession)
        {
            throw new NotImplementedException();
        }
    }
}
