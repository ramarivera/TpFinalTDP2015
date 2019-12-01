using Questionnaire.Model;
using Questionnaire.Services.DTO;
using System;
using System.Collections.Generic;

namespace Questionnaire.Services.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAll();

        Category GetById(int pCategoryId);

        Category Create(CategoryData pCategoryData);

        CategoryData RetrieveOrCreateByDescription(string pCategoryDescription);
    }
}
