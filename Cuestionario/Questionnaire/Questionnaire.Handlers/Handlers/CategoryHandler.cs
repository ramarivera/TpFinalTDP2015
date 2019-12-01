using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    /// <summary>
    /// Handler class for <see cref="Model.Category"/> related use cases such as: <see cref="GetAll"/> 
    /// </summary>
    class CategoryHandler : BaseHandler, ICategoryHandler
    {
        private readonly ICategoryServices iCategoryServices;
        private readonly ILogger iLogger;

        public CategoryHandler(
            ICategoryServices pCategoryServices,
            ILogger pLogger,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iCategoryServices = pCategoryServices;
            this.iLogger = pLogger;
        }

        /// <summary>
        /// Gets all Categories
        /// </summary>
        /// <returns>A list of <see cref="CategoryData"/></returns>
        [Transactional]
        public IEnumerable<CategoryData> GetAll()
        {
            this.iLogger.LogInformation("Request received for getting all existing Categories");
            
            var lCategories = iCategoryServices.GetAll();

            var lResult = Mapper.Map<IList<CategoryData>>(lCategories);

            this.iLogger.LogInformation("Request finished for getting all existing Categories");
            return lResult;
        }
    }
}
