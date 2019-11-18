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
    /// <summary>
    /// Handler class for <see cref="Model.Difficulty"/> related use cases such as: <see cref="GetAll"/> 
    /// </summary>
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

        /// <summary>
        /// Gets all Difficulties
        /// </summary>
        /// <returns>A list of <see cref="DifficultyData"/></returns>
        [Transactional]
        public IEnumerable<DifficultyData> GetAll()
        {
            var lDifficulties = iDifficultyServices.GetAll();

            var lResult = Mapper.Map<IList<DifficultyData>>(lDifficulties);
            return lResult;
        }
    }
}
