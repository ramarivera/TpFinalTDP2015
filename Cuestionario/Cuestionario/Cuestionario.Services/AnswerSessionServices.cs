using Questionnaire.Model;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;

namespace Cuestionario.Services
{
    public class AnswerSessionServices : IAnswerSessionServices
    {
        private readonly ISessionFactory iSessionFactory;

        private readonly ICategoryServices iCategoryServices;

        private readonly IDifficultyServices iDifficultyServices;

        private readonly IUserAnswerServices iUserAnswerServices;

        public AnswerSessionServices(
            ISessionFactory pSessionFactory,
            ICategoryServices pCategoryServices,
            IDifficultyServices pDificcultyServices,
            IUserAnswerServices pUserAnswerServces)
        {
            iSessionFactory = pSessionFactory;
            iCategoryServices = pCategoryServices;
            iDifficultyServices = pDificcultyServices;
            iUserAnswerServices = pUserAnswerServces;
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
                Category = lCategory,
                Difficulty = lDifficulty
            };

            this.Session.Save(lAnswerSession);

            return lAnswerSession;
        }

        public AnswerSession EndSession(int pAnswerSessionId)
        {
            var lAnswerSession = this.GetById(pAnswerSessionId);

            lAnswerSession.SessionDuration = (DateTime.Now - lAnswerSession.StartTime).TotalSeconds;
            
            int lDifficultyFactor = iDifficultyServices.GetDifficultyFactor(lAnswerSession.Difficulty.Description);

            int lTimeFactor = this.GetTimeFactor(lAnswerSession);

            lAnswerSession.Score = this.GetSessionScore(pAnswerSessionId, lDifficultyFactor, lTimeFactor);

            this.Session.Update(lAnswerSession);

            return lAnswerSession;
        }

        private double GetSessionScore(int pAnswerSessionId, int pDifficultyFactor, int pTimeFactor)
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

        private int GetTimeFactor(AnswerSession pAnswerSession)
        {
            int lTimeFactor = 0;
            double lTimePerQuestion = (pAnswerSession.Answers.Count() / pAnswerSession.SessionDuration);

            if (lTimePerQuestion < 5) { lTimeFactor = 5; }
            else if (lTimePerQuestion >= 5 && lTimePerQuestion <= 20) { lTimeFactor = 5; }
            else if (lTimePerQuestion > 20) { lTimeFactor = 1; }

            return lTimeFactor;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AnswerSession> GetAll()
        {
            IQueryable<AnswerSession> lAnswerSessions =
                this.Session.Query<AnswerSession>();

            return lAnswerSessions;
        }        

        public AnswerSession GetById(long pAnswerSessionId)
        {
            var lAnswerSession = GetAll()
                .FirstOrDefault(x => x.Id == pAnswerSessionId);

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

        private ISession Session => this.iSessionFactory.GetCurrentSession();
    }
}
