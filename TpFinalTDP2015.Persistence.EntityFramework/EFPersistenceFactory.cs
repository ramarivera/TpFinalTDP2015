using MarrSystems.TpFinalTDP2015.CrossCutting.Attributes;
using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    [CanResolve(typeof(IUnitOfWork), typeof(IRepository<Campaign>), typeof(IRepository<Banner>),
        typeof(IRepository<BaseBannerItem>), typeof(IRepository<Schedule>), typeof(IRepository<Schedule>),
        typeof(ManageScheduleHandler),
        typeof(ManageScheduleHandler), typeof(ManageTextHandler))]
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
