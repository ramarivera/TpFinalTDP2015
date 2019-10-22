using Cuestionario.Model;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Handlers.Handlers
{
    class DifficultyHandler : BaseHandler, IDifficultyHandler
    {
        private readonly IDifficultyServices iDifficultyServices;

        public DifficultyHandler(IDifficultyServices pDifficultyServices)
        {
            this.iDifficultyServices = pDifficultyServices;
        }

        [Transactional]
        public IList<Difficulty> GetAll()
        {
            //ver si no habria que mapear
            return iDifficultyServices.GetAll().ToList();
        }
    }
}
