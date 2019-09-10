using Cuestionario.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuestionario.Model;
using Cuestionario.Services.DTO;
using NHibernate;

namespace Cuestionario.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ISession _session;
        public CategoryServices(ISession session)
        {
            _session = session;
        }
        public Category Create(CategoryDTO pCategory)
        {
            Category lCategory = new Category
            {
                Description = pCategory.Description
            };

            _session.Save(lCategory);
            _session.Transaction.Commit();

            return lCategory;
        }

        public void Delete(long pId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            IQueryable<Category> lCategories =
                _session.Query<Category>();

            return lCategories;
        }

            //var sessionFactory = NHibernateHelper.CreateSessionFactory();

            //using (var session = sessionFactory.OpenSession())
            //{
            //    using (session.BeginTransaction())
            //    {
            //        IQueryable<Category> lCategories =
            //            session.Query<Category>();
            //        return lCategories;
            //    }
            //}            
        
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

        public Category Update(long pId, CategoryDTO pUpdateCategory)
        {
            throw new NotImplementedException();
        }

        public Category GetByDescription(string pCategoryDescription)
        {
            var lCategory = GetAll()
                    .FirstOrDefault(x => x.Description == pCategoryDescription);

            if (lCategory == null)
            {
                var lCategoryDTO = new CategoryDTO
                {
                    Description = pCategoryDescription
                };

                lCategory = Create(lCategoryDTO);
            }

            return lCategory;
        }
    }
}
