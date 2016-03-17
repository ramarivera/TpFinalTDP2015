using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class BusinessServiceFactory : IBusinessServiceFactory
    {
        private readonly IPersistenceFactory iFactory;

        public BusinessServiceFactory(IPersistenceFactory pFactory)
        {
            this.iFactory = pFactory;
        }

        public T GetService<T>() where T : IBusinessService
        {
            throw new NotImplementedException();
        }
    }
}
