using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Questionnaire.Model;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    class CategoryHandler : BaseHandler, ICategoryHandler
    {
        private readonly ICategoryServices iCategoryServices;

        public CategoryHandler(
            ICategoryServices pCategoryServices,
            IMapper pMapper)
            : base(pMapper)
        {
            this.iCategoryServices = pCategoryServices;
        }

        [Transactional]
        public IEnumerable<CategoryData> GetAll()
        {
            var lCategories = iCategoryServices.GetAll();

            var lResult = Mapper.Map<IList<CategoryData>>(lCategories);
            return lResult;
        }
    }
}
