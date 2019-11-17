using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Services.DTO;
using Questionnaire.Services.Interfaces;
using NHibernate;
using System;
using System.Linq;

namespace Questionnaire.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> iCategoryRepository;

        public CategoryServices(IRepository<Category> pCategoryRepository)
        {
            this.iCategoryRepository = pCategoryRepository;
        }

        /// <summary>
        /// Persist a Category in the database
        /// </summary>
        /// <param name="pCategoryData"></param>
        /// <returns></returns>
        public Category Create(CategoryData pCategoryData)
        {
            Category lCategory = new Category
            {
                Description = pCategoryData.Description
            };

            this.iCategoryRepository.Add(lCategory);

            return lCategory;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            return this.iCategoryRepository.GetAll();
        }       
        
        public Category GetById(long pCategoryId)
        {
            var lCategory = iCategoryRepository.GetById(pCategoryId);

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

        /// <summary>
        /// Retrieve a Category by description, if it doesn´t exist create it
        /// </summary>
        /// <param name="pCategoryDescription"></param>
        /// <returns></returns>
        public CategoryData RetrieveByDescription(string pCategoryDescription)
        {
            var lCategory = this.GetAll()
                    .FirstOrDefault(x => x.Description == pCategoryDescription);

            if (lCategory == null)
            {
                var lCategoryCreationData = new CategoryData
                {
                    Description = pCategoryDescription
                };

                lCategory = this.Create(lCategoryCreationData);
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
