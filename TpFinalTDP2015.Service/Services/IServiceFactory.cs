using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Services
{
    public interface IServiceFactory
    {
        IBusinessService GetBusinessService(Type pType);

        T GetBusinessService<T>() where T : IBusinessService;

        IDomainService GetDomainService(Type pType);

        T GetDomainService<T>() where T : IDomainService;

    }
}