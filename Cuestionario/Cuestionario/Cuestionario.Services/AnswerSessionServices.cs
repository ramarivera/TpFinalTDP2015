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

        public AnswerSessionServices(
            ISessionFactory pSessionFactory,
            ICategoryServices categoryServices,
            IDifficultyServices dificcultyServices)
        {
            iSessionFactory = pSessionFactory;
            iCategoryServices = categoryServices;
            iDifficultyServices = dificcultyServices;
        }

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
