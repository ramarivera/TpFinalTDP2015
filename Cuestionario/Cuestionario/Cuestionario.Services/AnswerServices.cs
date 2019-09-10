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
    public class AnswerServices : IAnswerServices
    {
        private ISession _session;

        private IQuestionServices _questionServeces;
        public AnswerServices(
            ISession session,
            IQuestionServices questionServices)
        {
            _session = session;
            _questionServeces = questionServices;
        }

        public Answer Create(AnswerDTO pAnswer)
        {
            var lQuestion = _questionServeces.GetById(pAnswer.Question.Id);

            Answer lAnswer = new Answer
            {
                Description = pAnswer.Description,
                Correct = pAnswer.Correct,
                Question = lQuestion
            };

            _session.Save(lAnswer);
            _session.Transaction.Commit();

            return lAnswer;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Answer> GetAll()
        {
            IQueryable<Answer> lAnswers =
                _session.Query<Answer>();

            return lAnswers;
        }      

        public Answer GetById(long pAnswerId)
        {
            var lAnswer = GetAll()
                .FirstOrDefault(x => x.Id == pAnswerId);

            if (lAnswer == null)
            {
                throw new ArgumentException($"Answer with Id {pAnswerId} was not found");
            }

            return lAnswer;
        }

        public Answer Update(long pId, AnswerDTO pUpdateAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
