using AutoMapper;
using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace Questionnaire.Handlers.Handlers
{
    // TODO missing documentation
    class DifficultyHandler : BaseHandler, IDifficultyHandler
    {
        private readonly IDifficultyServices iDifficultyServices;

        public DifficultyHandler(
            IDifficultyServices pDifficultyServices,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iDifficultyServices = pDifficultyServices;
        }

        [Transactional]
        public IEnumerable<DifficultyData> GetAll()
        {
            var lDifficulties = iDifficultyServices.GetAll();

            var lResult = Mapper.Map<IList<DifficultyData>>(lDifficulties);
            return lResult;
        }
    }
}
