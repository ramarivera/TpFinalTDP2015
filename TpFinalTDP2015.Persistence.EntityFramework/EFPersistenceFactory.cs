﻿using MarrSystems.TpFinalTDP2015.CrossCutting.Attributes;
using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    class EFPersistenceFactory : IPersistenceFactory
    {

        IDbContextFactory iFactory;
        EFUnitOfWork iUoW;

        public EFPersistenceFactory(IDbContextFactory pFactory)
        {
            this.iFactory = pFactory;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {

            return (IRepository<T>) this.GetRepository(typeof(T));
            
        }

        public  IUnitOfWork CreateUnitOfWork()
        {
            return iUoW = new EFUnitOfWork(this.iFactory.CreateContext());
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return iUoW;
        }

        public IRepository<BaseEntity> GetRepository(Type pType)
        {
            if (iUoW != null)
            {
                return iUoW.GetRepository(pType);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
