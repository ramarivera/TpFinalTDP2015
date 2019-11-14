using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Services.Interfaces
{
    public interface ICategoryServices
    {
        IQueryable<Category> GetAll();
        Category GetById(long pCategoryId);
        //Category Create(CategoryCreationData pCategoryData);
        Category Create(CategoryData pCategoryData);
        Category Update(long pCategoryId, CategoryData pUpdateCategory);
        void Delete(long pCategoryId);
        CategoryData RetrieveByDescription(string pCategoryDescription);
    }
}
