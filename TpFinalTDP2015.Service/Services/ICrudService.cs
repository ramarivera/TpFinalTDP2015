using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
   public interface ICrudService<TEntity>  where TEntity : BaseEntity
    {
        int Create(TEntity pEntity);

        TEntity Read(int pId);

        int Update(TEntity pEntity);

        void Delete(int pId);

        IEnumerable<TEntity> GetAll();
    }
}
