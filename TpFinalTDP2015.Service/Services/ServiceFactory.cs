using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IBusinessServiceFactory iBusiFact;
        private readonly IDomainServiceFactory iDomaFact;

        public ServiceFactory(IBusinessServiceFactory pBusiFact, IDomainServiceFactory pDomaFact)
        {
            this.iBusiFact = pBusiFact;
            this.iDomaFact = pDomaFact;
        }

        public IBusinessServiceFactory BusinessServiceFactory
        {
            get
            {
                return this.iBusiFact;
            }
        }

        public IDomainServiceFactory DomainServiceFactory
        {
            get
            {
                return this.iDomaFact;
            }
        }
    }
}