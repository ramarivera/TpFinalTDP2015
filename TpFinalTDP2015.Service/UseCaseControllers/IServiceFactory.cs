using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IServiceFactory
    {
        IDomainServiceFactory DomainServiceFactory { get; }


        IBusinessServiceFactory BusinessServiceFactory { get; }



    }
}