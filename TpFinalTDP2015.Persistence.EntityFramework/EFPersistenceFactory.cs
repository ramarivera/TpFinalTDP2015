﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    class EFPersistenceFactory : IPersistenceFactory
    {

        IDbContextFactory iFactory;

        public EFPersistenceFactory(IDbContextFactory pFactory)
        {
            this.iFactory = pFactory;
        }
        
        IRepository<T> IPersistenceFactory.CreateRepository<T>(IUnitOfWork pUoW)
        {
            var lUow = pUoW as EFUnitOfWork;
            if (lUow != null)
            {
                return lUow.GetRepository<T>();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        IUnitOfWork IPersistenceFactory.CreateUnitOfWork()
        {
            return new EFUnitOfWork(this.iFactory.CreateContext());
        }
    }
}