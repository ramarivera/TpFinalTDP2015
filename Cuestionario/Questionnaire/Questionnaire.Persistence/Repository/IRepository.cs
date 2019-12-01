using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System.Collections.Generic;

namespace Questionnaire.Persistence.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        TEntity FindById(int pId);

        IEnumerable<TEntity> FindBy(ISpecification<TEntity> pSpecification);

        IEnumerable<TEntity> ToList();

        void Add(TEntity pEntityToAdd);

        void Update(TEntity pEntityToUpdate);

        void DeleteById(int pId);

        void Delete(TEntity pEntityToDelete);
    }
}
