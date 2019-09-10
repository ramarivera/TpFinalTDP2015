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
        Category Create(CategoryDTO pCategory);
        Category Update(long pCategoryId, CategoryDTO pUpdateCategory);
        void Delete(long pCategoryId);
    }
}
