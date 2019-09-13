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
    public class AnswerSessionServices : IAnswerSessionServices
    {
        private ISession _session;

        private ICategoryServices _categoryServices;

        private IDifficultyServices _difficultyServices;

        public AnswerSessionServices(
            ISession session,
            ICategoryServices categoryServices,
            IDifficultyServices dificcultyServices)
        {
            _session = session;
            _categoryServices = categoryServices;
            _difficultyServices = dificcultyServices;
        }

        public AnswerSession Create(AnswerSessionCreationData pAnswerSessionData)
        {
            var lCategory = _categoryServices.GetById(pAnswerSessionData.Category.Id);

            var lDifficulty = _difficultyServices.GetById(pAnswerSessionData.Difficulty.Id);

            AnswerSession lAnswerSession = new AnswerSession
            {
                Username = pAnswerSessionData.Username,
                AnswerTime = pAnswerSessionData.AnswerTime,
                Score = pAnswerSessionData.Score,
                Date = pAnswerSessionData.Date,
                Category = lCategory,
                Difficulty = lDifficulty
            };

            _session.Save(lAnswerSession);
            _session.Transaction.Commit();

            return lAnswerSession;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AnswerSession> GetAll()
        {
            IQueryable<AnswerSession> lAnswerSessions =
                _session.Query<AnswerSession>();

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
    }
}
