using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    class DomainServiceFactory : IDomainServiceFactory
    {
        IDomainService IDomainServiceFactory.GetService(Type pType)
        {
            throw new NotImplementedException();
        }

        T IDomainServiceFactory.GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
