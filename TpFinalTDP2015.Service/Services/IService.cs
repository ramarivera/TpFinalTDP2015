using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
   public interface IService<TEntity> : IDisposable where TEntity : BaseEntity
    {

        IList<TEntity> GetAll();

        TEntity Get(int pId);

        void Delete(int pId);

        int Save(TEntity pEntity);
    }
}
