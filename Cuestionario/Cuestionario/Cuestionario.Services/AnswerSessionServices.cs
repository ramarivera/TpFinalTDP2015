using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using System;
using System.Linq;
using Questionnaire.Persistence.Repository;
using System.Collections.Generic;

namespace Questionnaire.Services
{
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
        /// Initialize an Answer Session
        /// </summary>
        /// <param name="pAnswerSessionStartData"> Answer Session's inicial data</param>
        /// <returns></returns>
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
        /// Finalize an Answer Session
        /// </summary>
        /// <param name="pAnswerSessionId"></param>
        /// <returns>The Answer Session with all its attributes completed</returns>
        public AnswerSession EndSession(long pAnswerSessionId)
        {
            var lAnswerSession = this.GetById(pAnswerSessionId);

            lAnswerSession.EndTime = DateTime.Now;
            
            // TODO difficultyFactor podría estar en los servicios de OpenTrivia por estar basado a las dificultades que este provider define
            int lDifficultyFactor = iDifficultyServices.GetDifficultyFactor(lAnswerSession.Difficulty.Description);

            int lTimeFactor = this.GetTimeFactor(lAnswerSession);

            lAnswerSession.Score = this.GetSessionScore(pAnswerSessionId, lDifficultyFactor, lTimeFactor);

            this.iAnswerSessionRepository.Update(lAnswerSession);

            return lAnswerSession;
        }

        /// <summary>
        /// Calculates the score of an Answer Session
        /// </summary>
        /// <param name="pAnswerSessionId"></param>
        /// <param name="pDifficultyFactor"></param>
        /// <param name="pTimeFactor"></param>
        /// <returns></returns>
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
        /// Calculates the score per answer based on the total duration and amount of questions of the given Answer Session
        /// </summary>
        /// <param name="pAnswerSession"></param>
        /// <returns></returns>
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

        public IEnumerable<AnswerSession> GetAll()
        {
            return this.iAnswerSessionRepository.GetAll();
        }        

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
