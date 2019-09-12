using Cuestionario.Model;
using Cuestionario.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.Interfaces
{
    public interface ICategoryServices
    {
        IQueryable<Category> GetAll();
        Category GetById(long pCategoryId);
        Category Create(CategoryCreationData pCategoryData);
        Category Update(long pCategoryId, CategoryData pUpdateCategory);
        void Delete(long pCategoryId);
        CategoryData RetrieveByDescription(string pCategoryDescription);
    }
}
