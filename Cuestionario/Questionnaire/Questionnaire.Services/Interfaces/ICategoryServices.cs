using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAll();
        Category GetById(long pCategoryId);
        Category Create(CategoryData pCategoryData);
        Category Update(long pCategoryId, CategoryData pUpdateCategory);
        void Delete(long pCategoryId);
        CategoryData RetrieveByDescription(string pCategoryDescription);
    }
}
