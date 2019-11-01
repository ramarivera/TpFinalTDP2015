using Cuestionario.Model;
using Cuestionario.Services.DTO;
using Cuestionario.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;

namespace Cuestionario.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ISession iSession;

        public CategoryServices(ISession pSession)
        {
            iSession = pSession;
        }

        public Category Create(CategoryData pCategoryData)
        {
            Category lCategory = new Category
            {
                Description = pCategoryData.Description
            };

            iSession.Save(lCategory);

            return lCategory;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            IQueryable<Category> lCategories =
                iSession.Query<Category>();

            return lCategories;
        }       
        
        public Category GetById(long pCategoryId)
        {
            var lCategory = GetAll()
                .FirstOrDefault(x => x.Id == pCategoryId);

            if (lCategory == null)
            {
                throw new ArgumentException($"Category with Id {pCategoryId} was not found");
            }

            return lCategory;
        }

        public Category Update(long pId, CategoryData pUpdateCategory)
        {
            throw new NotImplementedException();
        }

        public CategoryData RetrieveByDescription(string pCategoryDescription)
        {
            var lCategory = GetAll()
                    .FirstOrDefault(x => x.Description == pCategoryDescription);

            if (lCategory == null)
            {
                var lCategoryCreationData = new CategoryData
                {
                    Description = pCategoryDescription
                };

                lCategory = Create(lCategoryCreationData);
            }

            CategoryData lCategoryData = new CategoryData
            {
                Id = lCategory.Id,
                Description = pCategoryDescription
            };

            return lCategoryData;
        }
    }
}
