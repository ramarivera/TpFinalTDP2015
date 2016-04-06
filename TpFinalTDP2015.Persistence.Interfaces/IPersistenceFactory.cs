using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence
{
    public interface IPersistenceFactory
    {
        IUnitOfWork CreateUnitOfWork();

        IUnitOfWork GetUnitOfWork();

        IRepository<T> GetRepository<T>() where T : BaseEntity;

        IRepository<BaseEntity> GetRepository(Type pType);




    }
}
