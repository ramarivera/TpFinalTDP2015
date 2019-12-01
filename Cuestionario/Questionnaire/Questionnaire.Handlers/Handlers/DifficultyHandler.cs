using AutoMapper;
using Microsoft.Extensions.Logging;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;
using System.Collections.Generic;


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
            ILogger pLogger,
            IMapper pMapper)
            : base(pMapper, pLogger)
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
            this.Logger.LogInformation("Request received for getting all existing Difficulties");

            var lDifficulties = iDifficultyServices.GetAll();

            var lResult = Mapper.Map<IList<DifficultyData>>(lDifficulties);

            this.Logger.LogInformation("Request finished for getting all existing Difficulties");
            return lResult;
        }
    }
}
