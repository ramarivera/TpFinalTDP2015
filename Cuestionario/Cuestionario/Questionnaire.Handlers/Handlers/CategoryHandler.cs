using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.Interfaces;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Handlers.Handlers.Interfaces;

namespace Questionnaire.Handlers.Handlers
{
    class CategoryHandler : BaseHandler, ICategoryHandler
    {
        private readonly ICategoryServices iCategoryServices;

        public CategoryHandler(ICategoryServices pCategoryServices)
        {
            this.iCategoryServices = pCategoryServices;
        }

        [Transactional]
        public IList<Category> GetAll()
        {
            //ver si no habria que mapear
            return iCategoryServices.GetAll().ToList();
        }
    }
}
