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
    public class QuestionServices : IQuestionServices
    {
        private ISession _session;

        private ICategoryServices _categoryServices;

        private IDifficultyServices _difficultyServices;

        public QuestionServices(
            ISession session,
            ICategoryServices categoryServices,
            IDifficultyServices dificcultyServices)
        {
            _session = session;
            _categoryServices = categoryServices;
            _difficultyServices = dificcultyServices;
        }

        public Question Create(QuestionDTO pQuestion)
        {
            var lCategory = _categoryServices.GetById(pQuestion.Category.Id);

            var lDifficulty = _difficultyServices.GetById(pQuestion.Difficulty.Id);

            Question lQuestion = new Question
            {
                Description = pQuestion.Description,
                Category = lCategory,
                Difficulty = lDifficulty
            };

            //faltaría agregar las respuestas relacionadas

            _session.Save(lQuestion);
            _session.Transaction.Commit();

            return lQuestion;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Question> GetAll()
        {
            IQueryable<Question> lDifficulties =
                _session.Query<Question>();

            return lDifficulties;
        }         

        public Question GetById(long pQuestionId)
        {
            var lQuestion = GetAll()
                .FirstOrDefault(x => x.Id == pQuestionId);

            if (lQuestion == null)
            {
                throw new ArgumentException($"Question with Id {pQuestionId} was not found");
            }

            return lQuestion;
        }

        public Question Update(long pId, QuestionDTO pUpdateQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
